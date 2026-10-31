# Sprint 1 — Modelagem inicial e encapsulamento

## A. Identificação

- **Grupo:** _(preencher)_
- **Integrantes:** `@ItalloOtavio`, `@Manuela-Souza`, `@AlehMartins`, `@Wtsjr`, `@Duda1301`
- **Número da sprint:** 1
- **Período:** _(dd/mm/aaaa a dd/mm/aaaa)_
- **Responsável pelo acompanhamento:** _(preencher)_

## B. Objetivo da sprint

Entregar uma primeira versão executável do UrbanDrive que represente veículos com dados encapsulados e validados. A versão deve impedir a criação de veículos com dados inválidos e comprovar isso com testes automatizados e uma demonstração no console. Ao final, o repositório e o fluxo de trabalho do grupo devem estar prontos para as próximas sprints.

## C. Itens selecionados do Product Backlog

| ID | Requisito ou item | Prioridade | Justificativa |
|---|---|---|---|
| PB01 | Estrutura do projeto C# e repositório GitHub | Alta | Todos os outros itens dependem da solução e do repositório configurados. |
| PB02 | Fluxo de trabalho no GitHub | Alta | Precisa estar combinado antes do primeiro código para que cada integrante tenha contribuições identificáveis. |
| PB03 | Modelagem inicial das entidades | Alta | Exigida no escopo da Sprint 1. Dá ao grupo uma visão do sistema inteiro antes de implementar. |
| PB04 | Classe `Veiculo` com encapsulamento e validação (RF01) | Alta | É a base da hierarquia de veículos, da frota e da locação nas sprints seguintes. Usa só encapsulamento e construtores, que são o conteúdo desta sprint. |

## D. Planejamento das tarefas

Unidade de estimativa: **horas de trabalho**.

| ID | Tarefa | Item relacionado | Responsável | Estimativa |
|---|---|---|---|---|
| T01 | Criar a solução C# com os projetos `UrbanDrive.Models`, `UrbanDrive.App` (console) e `UrbanDrive.Tests` (xUnit) | PB01 | `@Wtsjr` | 2 h |
| T02 | Criar o `.gitignore` (ignorando `.vs/`, `bin/` e `obj/`), a pasta `docs/` e remover o `Veiculo.cs` solto na raiz | PB01 | `@Wtsjr` | 0,5 h |
| T03 | Combinar o padrão de branches (`feature/`, `fix/`, `docs/`), Conventional Commits e a regra de revisão por pull request; registrar no README | PB02 | `@ItalloOtavio` | 1 h |
| T04 | Elaborar o Product Backlog inicial priorizado (`docs/product-backlog.md`) | Planejamento | `@ItalloOtavio` | 2 h |
| T05 | Desenhar o diagrama de classes inicial com `Veiculo` detalhada e as demais entidades previstas (só nomes e ligações) em `docs/diagramas/` | PB03 | `@Duda1301` | 2 h |
| T06 | Implementar `Veiculo` com Id, Placa, Modelo e ValorDiaria usando atributos privados, propriedades públicas e construtor | PB04 | `@Manuela-Souza` | 2 h |
| T07 | Implementar as validações de `Veiculo` no construtor e nos setters das propriedades | PB04 | `@Manuela-Souza` | 2 h |
| T08 | Escrever os testes unitários de `Veiculo` (casos válidos e inválidos) | PB04 | `@ItalloOtavio` | 3 h |
| T09 | Demonstrar no `Program.cs` a criação de veículos válidos e a tentativa de criar inválidos, tratando as exceções com `try/catch` | PB04 | `@AlehMartins` | 1,5 h |
| T10 | Registrar as evidências: saída do `dotnet test` e da demonstração no console, com capturas de tela, em `docs/evidencias/sprint-1/` | PB04 | `@AlehMartins` | 1 h |
| T11 | Preencher o resultado da sprint (seção G) e a retrospectiva (seção H) | Planejamento | `@Duda1301` | 1 h |
| | | | **Total** | **18 h** |

## E. Critérios de aceitação

**PB01 — Estrutura do projeto**
- `dotnet build` executa sem erros a partir da raiz do repositório.
- `dotnet run --project` do projeto de console executa e exibe a demonstração.
- `dotnet test` encontra e executa os testes do projeto `UrbanDrive.Tests`.
- As pastas `.vs/`, `bin/` e `obj/` não aparecem no repositório.

**PB02 — Fluxo de trabalho**
- O padrão de branches e de commits está descrito no README.
- Todo código desta sprint chegou à `main` por pull request revisado por outro integrante.
- Cada integrante tem pelo menos um commit próprio seguindo Conventional Commits.

**PB03 — Modelagem inicial**
- O diagrama está em `docs/diagramas/` e mostra `Veiculo` com seus atributos, propriedades e construtor.
- O diagrama inclui as entidades previstas na seção 3.1 do enunciado (`Carro`, `Patinete`, `CarroEletrico`, `Motorista`, `CNH`, `Frota`, `ConfiguradorSistema`, `Locacao`).

**PB04 — Classe Veiculo**
- Os campos de `Veiculo` são `private` e o acesso é feito apenas por propriedades públicas.
- Criar um veículo com dados válidos (ex.: Id 1, placa `ABC1D23`, modelo `Onix`, diária 150) preserva todos os valores informados.
- Placa nula, vazia ou só com espaços lança `ArgumentException` com mensagem que identifica o campo.
- Modelo nulo, vazio ou só com espaços lança `ArgumentException`.
- Valor da diária menor ou igual a zero lança `ArgumentOutOfRangeException`.
- Id menor ou igual a zero lança `ArgumentOutOfRangeException`.
- As mesmas validações valem ao alterar a propriedade depois da criação, e o valor anterior é mantido quando a alteração é rejeitada.
- Existe pelo menos um teste unitário para cada regra acima e todos passam.
- A demonstração no console mostra veículos válidos e as mensagens de erro dos inválidos, sem encerrar com exceção não tratada.

## F. Entregáveis previstos

- **Product Backlog inicial priorizado:** `docs/product-backlog.md`.
- **Planejamento da sprint:** este documento.
- **Código-fonte:** solução C# com a classe `Veiculo` em `UrbanDrive.Models` e a demonstração em `UrbanDrive.App`.
- **Diagrama de classes inicial:** `docs/diagramas/`.
- **Demonstração:** execução do console criando veículos válidos e rejeitando inválidos.
- **Evidências de testes:** testes em `UrbanDrive.Tests`, além da saída do `dotnet test` e das capturas de tela em `docs/evidencias/sprint-1/`.
- **Resultado da sprint:** seções G e H deste documento.

## G. Resultado da sprint

_Preencher ao final da sprint com a situação real (concluído, parcialmente concluído ou não concluído). Não alterar as seções A a F para esconder diferenças; registrar aqui as mudanças e suas justificativas._

| Item ou tarefa | Situação | Evidência | Observações |
|---|---|---|---|
| T01 | Concluído | PR #63; `dotnet build` sem erros | Solução com `UrbanDrive.Models`, `UrbanDrive.App` e `UrbanDrive.Tests`. O `Class1.cs` gerado pelo template foi removido no PR #72. |
| T02 | Concluído | PR #64; `.gitignore` na raiz | `.vs/`, `bin/` e `obj/` não aparecem no repositório. |
| T03 | Concluído | PR #62; seção de fluxo de trabalho no `README.md` | |
| T04 | Concluído | PR #60; `docs/product-backlog.md` | |
| T05 | Concluído | PR #65; `docs/diagramas/diagrama-classes-sprint-1.png` | Diagrama corrigido e convertido de `.jpg` para `.png` no PR #72. |
| T06 | Concluído | PR #66; `src/UrbanDrive.Models/Entities/Veiculo.cs` | |
| T07 | Concluído | PR #67; `Veiculo.cs` | Exceções de Id e diária trocadas para `ArgumentOutOfRangeException` no PR #68, conforme os critérios de aceitação. |
| T08 | Concluído | PR #69; `UrbanDrive.Tests` com 22 testes aprovados | |
| T09 | Concluído | PR #70; `src/UrbanDrive.App/Program.cs` | Demonstração completada no PR #71 com um caso inválido para cada regra. |
| T10 | Concluído | PRs #70 e #71; `docs/evidencias/sprint-1/` | Capturas `resultado-testes.png` e `demonstracao-console.png`. |
| T11 | Concluído | PR #74; seções G e H deste documento | |

**Pendências:** nenhuma pendência técnica. Todas as tarefas planejadas foram concluídas e os 22 testes passam.

**Decisões revistas:**
- A propriedade da diária foi implementada como `ValorBaseDiaria` em vez de `ValorDiaria`, como estava no planejamento (T06). O nome deixa claro que é o valor base, sobre o qual as próximas sprints vão aplicar o cálculo de aluguel.
- Id e valor da diária inválidos passaram a lançar `ArgumentOutOfRangeException` em vez de `ArgumentException` (PR #68), para seguir os critérios de aceitação do PB04.
- A pasta de evidências foi renomeada de `docs/evidencias/sprint1` para `docs/evidencias/sprint-1` (PR #71), para seguir o caminho previsto no planejamento.

## H. Retrospectiva

**O que funcionou bem?**
Um dos pontos que deu certo durante a sprint foi a divisão de tarefas entre os integrantes do grupo. Cada membro ficou responsável por atividades específicas, o que ajudou a organizar melhor o trabalho e permitiu que as tarefas fossem desenvolvidas de forma mais eficiente.

**Quais foram as principais dificuldades?**
A principal dificuldade encontrada durante a sprint foi o tempo disponível para a realização das tarefas. Para as próximas sprints, será importante melhorar a organização e o acompanhamento das atividades, buscando aproveitar melhor o tempo e cumprir os prazos estabelecidos.

**O planejamento foi adequado ao esforço necessário?**
Sim, o planejamento foi adequado ao esforço necessário, pois a divisão das tarefas permitiu que a equipe se organizasse melhor e realizasse as atividades dentro do período previsto.

**O que deverá ser melhorado na próxima sprint?**
Deverá ser melhorado o acompanhamento das tarefas durante a sprint, para identificar possíveis dificuldades com antecedência e garantir que todas as atividades sejam concluídas.
