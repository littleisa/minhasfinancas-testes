# Testes Automatizados - Minhas Finanças

Repositório contendo os testes automatizados do sistema de controle de gastos residenciais.

## Estrutura da Pirâmide de Testes

- **Testes Unitários**: validam regras de negócio isoladas (sem banco, sem API)
- **Testes de Integração**: validam a comunicação entre as camadas e o banco de dados
- **Testes E2E**: simulam o uso real do sistema pelo navegador (Playwright)

## Como rodar os testes

### Back-end (Unitários e Integração)
```bash
cd backend-tests/MinhasFinancas.Tests
dotnet restore --ignore-failed-sources
dotnet test
```

### Front-end (E2E)
```bash
cd frontend-tests
npm install
npx playwright test
```

## Bugs encontrados

### Bug 01 - nuget.config com caminho local inválido
O arquivo `api/nuget.config` referencia uma pasta que não existe em outros computadores, impedindo a compilação. Detalhes em `bugs/bug-01-nuget-config.md`.

### Bug 02 - Exclusão em cascata não configurada
O relacionamento entre Pessoa e Transação não tem cascade delete explícito, podendo causar falhas ao deletar pessoas com transações. Detalhes em `bugs/bug-02-cascade-delete.md`.

## Justificativa das escolhas

- **xUnit**: framework padrão e moderno para testes em .NET
- **InMemory Database**: permite testar integração sem depender de banco real
- **Playwright**: ferramenta robusta para testes E2E em aplicações React
- Foco nas **regras de negócio** conforme pedido, sem buscar 100% de cobertura