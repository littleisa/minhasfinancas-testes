# Bug 02 - Exclusão em cascata não configurada explicitamente

## O que é o problema
a regra de negócio diz que ao excluir uma Pessoa, todas as suas transações
devem ser excluídas junto (exclusão em cascata).

## Onde está o problema
Arquivo: `api/MinhasFinancas.Infrastructure/Data/MinhasFinancasDbContext.cs`

O relacionamento entre pessoa e transacao não tem o comportamento de cascade
delete configurado explicitamente.

## Risco
Dependendo do banco de dados utilizado, deletar uma Pessoa que possui
transações pode gerar erro de chave estrangeira ou deixar transações
sem dono no banco.

## Impacto
Regra de negócio pode não funcionar corretamente em todos os ambientes.