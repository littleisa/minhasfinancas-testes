# Bug 01 - Configuração do NuGet com caminho local inválido

## O que é o problema
O arquivo `api/nuget.config` referencia uma pasta local que não existe:
`C:\Program Files (x86)\Microsoft SDKs\NuGetPackages\`

## O que acontece na prática
Ao tentar compilar o projeto em outro computador, aparecem erros de restauração
de pacotes, impedindo que o projeto rode.

## Onde está o problema
Arquivo: `api/nuget.config`

## Como reproduzir
1. Clonar o repositório
2. Rodar `dotnet build` na pasta da API
3. Erro NU1301 aparece indicando que a fonte local não existe

## Impacto
Qualquer desenvolvedor que não tenha o Visual Studio instalado com os pacotes
offline não consegue compilar o projeto sem ajustes manuais.

## Atualização - Impacto maior do que o esperado

Ao referenciar outros projetos da solução (Application e Infrastructure),
o mesmo erro NU1301 aparece, confirmando que o problema afeta toda a solução
e não apenas o projeto Domain.

Projetos afetados:
- MinhasFinancas.Domain
- MinhasFinancas.Application
- MinhasFinancas.Infrastructure