# Product Backlog — UrbanDrive

Itens ordenados por prioridade (o primeiro da lista é o mais prioritário). A prioridade considera as dependências entre os itens e a ordem dos conteúdos de POO vistos nas aulas.

**Prioridade:** Alta = necessário para a sprint atual ou bloqueia outros itens · Média = depende de itens anteriores · Baixa = consolidação final.

| Ordem | ID | Item | Requisito | Prioridade | Depende de | Sprint prevista |
|---|---|---|---|---|---|---|
| 1 | PB01 | Estrutura do projeto C# (solução, projetos de modelos, console e testes) e repositório GitHub configurado | — | Alta | — | 1 |
| 2 | PB02 | Fluxo de trabalho no GitHub (padrão de branches, Conventional Commits e revisão por pull request) | — | Alta | PB01 | 1 |
| 3 | PB03 | Modelagem inicial das entidades (diagrama de classes com as entidades previstas) | — | Alta | — | 1 |
| 4 | PB04 | Classe `Veiculo` com Id, Placa, Modelo e ValorDiaria, encapsulamento e validação dos dados | RF01 | Alta | PB01 | 1 |
| 5 | PB05 | `Motorista` e `CNH` com composição (a CNH não existe sem o motorista) | RF03 | Alta | PB01 | 2 |
| 6 | PB06 | `Frota` agregando veículos (adicionar, remover, buscar e listar) | RF04 | Alta | PB04 | 2 |
| 7 | PB07 | `ConfiguradorSistema` com membros estáticos (taxas e contador de veículos) | RF07 | Alta | PB04 | 2 |
| 8 | PB08 | `Locacao` associando motorista e veículo | RF05 | Média | PB04, PB05 | 2 |
| 9 | PB09 | `Carro` e `Patinete` (sealed) herdando de `Veiculo`, com características próprias | RF02 | Média | PB04 | 3 |
| 10 | PB10 | Cálculo de aluguel polimórfico com `CalcularAluguel(int dias)` | RF05 | Média | PB08, PB09 | 3 |
| 11 | PB11 | Manutenção com sobrecarga: `RealizarManutencao()` e `RealizarManutencao(string pecaSubstituida)` | RF06 | Média | PB04 | 3 |
| 12 | PB12 | `Veiculo` abstrata e interface `IImprimivel` com `GerarRelatorio()` | RF08 | Média | PB09 | 4 |
| 13 | PB13 | Interface `IEletrico` com `Recarregar()`, aplicada a `Patinete` e `CarroEletrico` | RF09 | Média | PB09 | 4 |
| 14 | PB14 | Menu no console para cadastrar e consultar veículos e demonstrar seus comportamentos | RF10 | Média | PB06, PB10 | 4 |
| 15 | PB15 | Documentação de instalação e execução, apresentação e relatório final | — | Baixa | PB14 | 4 |

## Histórico de alterações

| Data | Alteração | Motivo |
|---|---|---|
| 30/10/2026 | Criação do backlog inicial | Planejamento da Sprint 1 |
