# Launcher Mod Suite

Este repositório contém três ferramentas legadas relacionadas ao Launcher do jogo MU: **ConfigGenerator**, **Update Generator** e **Launcher**. O objetivo deste documento é consolidar o plano de unificação e análise prévia para a criação de uma ferramenta única que integre esses módulos e acrescente um gerenciador de design.

## Estrutura atual da solução

A solução `LauncherSuite.sln` consolida os artefatos em cinco projetos principais:

| Projeto | Tipo | Descrição |
| --- | --- | --- |
| `LauncherSuite.Core` | Biblioteca | Serviços compartilhados para leitura/escrita do `mu.ini`, geração de manifestos de update, catálogo de temas e contratos de manifesto. |
| `ConfigGenerator` | WinForms | Ferramenta clássica reutilizada pela suíte via referência de projeto e abastecida pelo núcleo para manipular `mu.ini`. |
| `Update Generator` | WinForms | Modulo legado hospedado na suíte que aproveita o `UpdateManifestBuilder` do núcleo para copiar arquivos e calcular hashes. |
| `Launcher` | WinForms | Cliente original que continua responsável por aplicar temas e baixar atualizações, agora consumindo os contratos do núcleo. |
| `LauncherSuite.App` | WinForms | Shell unificado com abas para Configuração, Updates e Design Manager, incluindo assistente de criação de temas. |

## Plano estratégico proposto

### 1. Estrutura da solução unificada
- **Solução principal (`LauncherSuite.sln`)** com quatro projetos:
  1. `LauncherSuite.Core` (biblioteca de classes) — conterá modelos, serviços e utilitários compartilhados (manipulação do `mu.ini`, cálculo de hashes CRC, abstrações de storage de temas, etc.).
  2. `LauncherSuite.WinUI` (aplicativo desktop) — janela principal com navegação em abas ou wizard, hospedando os módulos de Configuração, Updates e Design.
  3. `LauncherSuite.Config` (UserControl) — refatoração do ConfigGenerator original para usar os serviços do núcleo.
  4. `LauncherSuite.Updates` (UserControl) — refatoração do Update Generator, reutilizando o núcleo para cálculo e cópia.
  5. `LauncherSuite.Design` (UserControl) — novo módulo de gerenciamento de temas.

### 2. Módulo ConfigGenerator (Refatorado)
- Extrair lógica de leitura/gravação do `mu.ini` para `LauncherSuite.Core.Configuration`.
- Converter o formulário WinForms existente em um UserControl; expor eventos/comandos para o shell principal.
- Implementar validação de campos e suporte a perfis salvos.

### 3. Módulo Update Generator (Refatorado)
- Migrar cálculo de hashes, geração de manifestos e rotina de cópia para serviços em `LauncherSuite.Core.Updates`.
- Encapsular configurações padrão (ex.: diretório de saída) e permitir presets.
- Acrescentar pré-visualização da estrutura do pacote antes da geração.

### 4. Formato de Tema (Design Manager)
- **Estrutura sugerida**:
  ```
  /ThemeName/
    theme.json            // metadados (nome, autor, versão, compatibilidade)
    images/
      background.png
      buttons/
        play.png
        exit.png
      icons/
        settings.png
    fonts/
    layout.xml            // (opcional) definições de posições/sizes se necessárias
  ```
- `theme.json` deve mapear as imagens obrigatórias/opcionais e parâmetros (cores, fontes).
- Definir contratos em `LauncherSuite.Core.Design` para validar, importar, exportar e aplicar temas.

### Persistência do design
- A aplicação do Launcher agora inicializa um repositório de temas em `./Themes/` exportando automaticamente o tema padrão com o arquivo de manifesto `theme.xml`.
- O manifesto descreve os assets obrigatórios (ex.: estados dos botões Start/Exit, opções de janela, plano de fundo e componentes da tela de opções) e aponta para arquivos `.png` organizados em subpastas (`images/start`, `images/exit`, `images/options`, etc.).
- A seleção de tema ativa é persistida no arquivo `LauncherOption.if` através da chave `Theme:<nome>`, permitindo que o gerenciador de design e o launcher retomem o layout customizado entre execuções.
- O loader de temas valida a presença dos assets exigidos, recarrega as imagens em memória e atualiza dinamicamente os controles do `MainForm` e da janela de opções, eliminando dependências diretas de `Resources.resx`.

### 5. Evolução do Launcher para suportar temas
- Adaptar o Launcher existente para carregar recursos de tema via:
  - Lookup em `LauncherSuite.Core.Design` e fallback para recursos embutidos.
  - Monitoramento de alterações (hot reload simples) durante o design.
- Garantir compatibilidade com Seasons: os temas podem ter variações por Season, referenciadas no `theme.json`.

### 6. Fluxo de Build/Deploy Automatizado
- Implementar um assistente com etapas sequenciais:
  1. Seleção/criação de configuração (`mu.ini`).
  2. Seleção de tema ou criação de novo.
  3. Geração de pacote de atualização (manifesto + arquivos).
  4. Resumo final com botões para exportar/empacotar.
- Opcional: integração com scripts MSBuild/PowerShell para gerar instaladores ou arquivar releases.

### 7. Migração incremental sugerida
1. Criar `LauncherSuite.Core` e mover lógica compartilhada dos geradores.
2. Portar ConfigGenerator e Update Generator para UserControls utilizando o núcleo.
3. Desenvolver o `Design Manager`, começando por importação/validação de temas.
4. Atualizar Launcher para consumir o novo formato de tema.
5. Integrar os três módulos na aplicação unificada e adicionar o assistente de build/deploy.
6. Automatizar testes (ex.: unit tests para parse do `mu.ini`, validação de tema, geração de hashes).

### 8. Considerações adicionais
- Documentar o formato de tema e APIs internas para facilitar criação de novas skins.
- Planejar testes com conjuntos de arquivos grandes para validar performance do Update Generator.
- Avaliar uso de WPF/WinUI 3 para interface moderna, mantendo compatibilidade com controles existentes via hostagem de WinForms quando necessário.
- Preparar scripts de migração para usuários existentes (importar configurações antigas, temas padrão).

## Análise dos projetos atuais

### ConfigGenerator
Aplicativo WinForms que gera o arquivo `mu.ini` com XOR simples, permitindo escolher versão do cliente, URLs e nome do executável antes de gravar as preferências com dois índices (versão e idioma) no início do arquivo.

### Update Generator
Ferramenta WinForms que varre uma pasta, calcula hashes CRC dos arquivos e produz uma lista `update.txt`, além de copiar os arquivos para uma estrutura `./update/` espelhando a hierarquia original para distribuição.

### Launcher
Carrega `mu.ini`, ativa modos específicos conforme a Season selecionada, atualiza UI e lógica (botões, webview, opções) e consome um conjunto fixo de bitmaps empacotados em `Resources.resx` para compor o design atual.

## Possibilidades de integração
1. **Camada de domínio compartilhada**
   - Criar uma biblioteca comum que encapsule leitura/escrita de `mu.ini`, cálculo de hashes e definição de estrutura de atualização. Isso evitaria duplicação de lógica entre módulos WinForms e permitiria expor serviços reutilizáveis pela nova ferramenta integrada.

2. **Interface unificada (WinForms ou WPF)**
   - Aproveitar os formulários existentes como base para abas ou seções em uma única aplicação: uma aba “Configuração” (ConfigGenerator), outra “Gerador de Updates” (Update Generator) e uma nova “Design Manager”.
   - Reaproveitar os controles e eventos atuais, movendo-os para UserControls que possam ser hospedados numa janela principal com navegação em abas.

3. **Gerenciador de Design**
   - O design atual é fixo via recursos estáticos; seria viável adicionar um módulo que gerencie pacotes de imagens (bitmaps) e arquivos `.resx` ou diretórios de temas para gerar builds personalizados do Launcher.
   - Uma abordagem é permitir importar/exportar conjuntos de imagens e gerar automaticamente um `Resources.resx` temático ou aplicar temas via arquivos externos lidos em tempo de execução, reduzindo necessidade de recompilação.

## Considerações técnicas e desafios
- **Refatoração de código decompilado**: os arquivos foram obtidos por engenharia reversa e carecem de padrões modernos (ex.: ausência de `using` seguros, nomes pouco expressivos). Antes de integrar, seria prudente refatorar para melhorar manutenibilidade.
- **Persistência do design**: como o Launcher espera recursos embutidos, será preciso definir como novos designs serão carregados (ex.: extraindo para pastas ou gerando builds). Alterar o Launcher para suportar skins externas exigirá ajustes para carregar bitmaps dinamicamente.
- **Compatibilidade com Seasons**: o `mu.ini` guarda índice da Season e idioma; qualquer integração deve preservar essa lógica para que o Launcher continue habilitando modos Season 9/12 corretamente.
- **Processo de atualização**: o gerador de updates copia arquivos para `./update/` e lista `.rar` virtual (note que a extensão `.rar` é apenas parte da string). Se a nova ferramenta alterar esse comportamento, o fluxo do patcher precisa ser validado para evitar inconsistências.

## Recomendações finais
1. Criar uma solução única em C# contendo projetos de biblioteca (núcleo) e um aplicativo principal que hospede os três módulos, com foco em reutilização.
2. Definir formato de tema padronizado para facilitar criação de pacotes de design.
3. Automatizar o fluxo de build/deploy para reduzir erros manuais.
4. Planejar uma migração incremental começando pela extração da lógica compartilhada dos geradores, seguida pela integração dos módulos em uma única ferramenta.

