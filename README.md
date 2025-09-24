# Launcher Mod Suite

A suíte consolida as ferramentas legadas **ConfigGenerator**, **Update Generator** e o **Design Manager** dentro de uma única experiência WinForms. O código compartilhado vive na biblioteca `LauncherSuite.Core`, permitindo reutilizar a serialização do `mu.ini`, a geração de manifestos de update e o catálogo de temas entre todos os módulos.

## Estrutura da solução

| Projeto | Tipo | Responsabilidade |
| --- | --- | --- |
| `LauncherSuite.Core` | Biblioteca | Serviços de domínio (`MuConfiguration`, `UpdateManifestBuilder`, `BuildPipeline`) e contratos de tema (`ThemeManifest`, catálogo de assets). |
| `ConfigGenerator` | WinForms | Controle reutilizável `ConfigGeneratorControl` para editar ou salvar `mu.ini` — ainda disponível como executável independente via `Form1`. |
| `Update Generator` | WinForms | Controle `UpdateGeneratorControl` que gera o `update.txt`, copia arquivos e expõe progresso reutilizável. |
| `Launcher` | WinForms | Launcher original capaz de consumir temas persistidos em disco através do manifesto padrão. |
| `LauncherSuite.App` | WinForms | Shell mestre com abas para Configuração, Updates, Design e o novo assistente de build que integra todo o fluxo. |

## Formato padronizado de temas

O manifesto `theme.xml` descreve os assets obrigatórios do Launcher. A estrutura padrão exportada pelo Design Manager e pela `BuildPipeline` segue o layout abaixo:

```
/MeuTema/
  theme.xml               # Metadados: nome, autor, versão, compatibilidade
  images/
    background.png
    start/
      idle.png
      hover.png
      pressed.png
      disabled.png
    exit/
      idle.png
      hover.png
      pressed.png
    settings/
      idle.png
      hover.png
      pressed.png
    windowmode/
      checked.png
      unchecked.png
    progress/
      bar.png
      overlay.png
    options/
      accept/
        idle.png
        hover.png
        pressed.png
      background.png
```

O `ThemeManifest` lista cada chave obrigatória (definida em `ThemeAssetCatalog`). A aplicação valida o diretório antes de aplicar o tema e exporta automaticamente os assets padrões quando solicitado.

## Automação de build/deploy

A aba **Build** do `LauncherSuite.App` encapsula todo o fluxo em quatro etapas:

1. **Configuração:** reutiliza o `ConfigGeneratorControl` para compor os campos do `mu.ini`. O caminho de saída pode ser ajustado diretamente no assistente.
2. **Updates:** importa a pasta selecionada no `UpdateGeneratorControl` (ou qualquer diretório informado) e gera o manifesto `update.txt` enquanto copia os arquivos para a pasta de distribuição.
3. **Tema:** opcionalmente cria um pacote de design completo, com possibilidade de incluir os assets padrão exportados pelo Launcher ou apenas a estrutura vazia.
4. **Execução:** aciona a `BuildPipeline`, salvando o `mu.ini`, montando a pasta `update`, gerando o `update.txt` e, se habilitado, criando o pacote de tema pronto para consumo em runtime.

O log do assistente apresenta cada arquivo listado no manifesto e a barra de progresso acompanha o cálculo do CRC. Ao final, são exibidos os caminhos gerados para auditoria.

## Migração incremental

O plano de evolução continua dividido em etapas independentes:

1. **Extração de domínio compartilhado** ✅ — `LauncherSuite.Core` contém a serialização do `mu.ini`, CRC32, manifestos de update, catálogo de temas e o `BuildPipeline` reutilizável.
2. **Refatoração dos geradores** ✅ — ConfigGenerator e Update Generator foram convertidos em `UserControl`s reutilizáveis, mantendo formulários de compatibilidade apenas como wrappers.
3. **Design Manager reutilizável** ✅ — Controle com validação, exportação do tema padrão e APIs reutilizadas pelo assistente de build.
4. **Launcher temático** ✅ — O cliente lê o manifesto `theme.xml`, carrega assets de disco e persiste o tema ativo em `LauncherOption.if`.
5. **Integração na ferramenta mestre** ✅ — `LauncherSuite.App` hospeda todos os módulos e fornece o assistente de build para reduzir erros manuais.
6. **Próximos passos sugeridos** ⏳ — Cobertura de testes automatizados (parse do `mu.ini`, validação de manifesto), integração com scripts de empacotamento/MSBuild e refino visual do shell (WinUI/WPF) permanecem como melhorias futuras.

Com essa base, novas personalizações podem compartilhar a mesma infraestrutura, evitando retrabalho e simplificando o deploy do Launcher modificado.
