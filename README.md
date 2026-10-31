# UrbanDrive

Sistema de gestão de mobilidade urbana para empresas de transporte multimodal: aluguel de veículos, patinetes elétricos e gestão de frotas corporativas.

Projeto da disciplina de Programação Orientada a Objetos, desenvolvido em **C#** como aplicação de console e organizado em quatro sprints. O enunciado completo está em [docs/enunciado.md](docs/enunciado.md).

## Sumário

- [Equipe](#equipe)
- [Andamento das sprints](#andamento-das-sprints)
- [Requisitos](#requisitos)
- [Estrutura do repositório](#estrutura-do-repositório)
- [Como executar](#como-executar)
- [Fluxo de trabalho](#fluxo-de-trabalho)
- [Documentação](#documentação)

## Equipe

| Integrante | GitHub |
|---|---|
| Itallo Otavio | [@ItalloOtavio](https://github.com/ItalloOtavio) |
| Manuela Souza | [@Manuela-Souza](https://github.com/Manuela-Souza) |
| Alexandre Martins | [@AlehMartins](https://github.com/AlehMartins) |
| Wagner Teofilo | [@Wtsjr](https://github.com/Wtsjr) |
| Maria Eduarda | [@Duda1301](https://github.com/Duda1301) |

As tarefas e seus responsáveis são acompanhados no [quadro do projeto](https://github.com/users/ItalloOtavio/projects/11).

## Andamento das sprints

| Sprint | Tema | Conceitos de POO | Planejamento | Situação |
|---|---|---|---|---|
| 1 | Modelagem inicial e encapsulamento | Classes, propriedades, construtores, validação | [sprint-1.md](docs/sprints/sprint-1.md) | Em andamento |
| 2 | Relacionamentos entre objetos e membros estáticos | Associação, agregação, composição, `static` | [sprint-2.md](docs/sprints/sprint-2.md) | Planejada |
| 3 | Herança, polimorfismo e especialização | Herança, `override`, sobrecarga, `sealed` | [sprint-3.md](docs/sprints/sprint-3.md) | Planejada |
| 4 | Abstração, interfaces e consolidação | Classes abstratas, interfaces | [sprint-4.md](docs/sprints/sprint-4.md) | Planejada |

## Requisitos

| ID | Requisito | Sprint prevista |
|---|---|---|
| RF01 | Gerenciamento de veículos (identificador, placa, modelo e valor da diária) | 1 |
| RF02 | Especialização de veículos (carros e patinetes) | 3 |
| RF03 | Gerenciamento de motoristas e CNHs | 2 |
| RF04 | Gerenciamento de frotas | 2 |
| RF05 | Cálculo de locação conforme o tipo de veículo | 2 e 3 |
| RF06 | Manutenção de veículos, com peça substituída opcional | 3 |
| RF07 | Configuração do sistema (taxas e contadores compartilhados) | 2 |
| RF08 | Relatórios por meio de um contrato comum | 4 |
| RF09 | Veículos elétricos e recarga | 4 |
| RF10 | Cadastro e consulta pela aplicação de console | 4 |

A priorização e as dependências entre os itens estão no [Product Backlog](docs/product-backlog.md).

## Estrutura do repositório

Estrutura prevista (a solução C# é criada na tarefa T01 da Sprint 1):

```
UrbanDrive/
├── src/
│   ├── UrbanDrive.Models/   # entidades, interfaces e regras de negócio
│   └── UrbanDrive.App/      # aplicação de console (Program.cs)
├── tests/
│   └── UrbanDrive.Tests/    # testes unitários (xUnit)
├── docs/
│   ├── enunciado.md         # enunciado do professor
│   ├── product-backlog.md   # backlog priorizado e seu histórico
│   ├── sprints/             # planejamento, resultado e retrospectiva de cada sprint
│   ├── diagramas/           # diagramas de classes
│   └── evidencias/          # saídas de testes e capturas de tela por sprint
├── .gitignore
└── README.md
```

## Como executar

Pré-requisito: [SDK do .NET](https://dotnet.microsoft.com/download) instalado.

```bash
# clonar o repositório
git clone https://github.com/ItalloOtavio/UrbanDrive.git
cd UrbanDrive

# compilar
dotnet build

# executar a aplicação de console
dotnet run --project src/UrbanDrive.App

# executar os testes
dotnet test
```

> Os comandos passam a funcionar quando a estrutura da solução (T01) estiver na `main`.

## Fluxo de trabalho

### Branches

A `main` mantém sempre uma versão estável. Cada tarefa é feita em uma branch própria, criada a partir da `main` atualizada:

| Prefixo | Uso | Exemplo |
|---|---|---|
| `feature/` | nova funcionalidade | `feature/classe-veiculo` |
| `fix/` | correção de erro | `fix/validacao-placa` |
| `docs/` | documentação e planejamento | `docs/planejamento-sprint-2` |
| `test/` | criação ou ajuste de testes | `test/veiculo` |

### Commits

Seguimos o padrão [Conventional Commits](https://www.conventionalcommits.org/pt-br/), com a mensagem no imperativo e em português:

| Tipo | Quando usar | Exemplo |
|---|---|---|
| `feat` | nova funcionalidade | `feat: implementa validacao da placa` |
| `fix` | correção de erro | `fix: corrige calculo de aluguel` |
| `test` | testes | `test: adiciona testes da classe Veiculo` |
| `docs` | documentação | `docs: atualiza diagrama de classes` |
| `refactor` | melhoria sem mudar o comportamento | `refactor: reorganiza gerenciamento da frota` |
| `chore` | configuração e manutenção do projeto | `chore: adiciona .gitignore` |

Mensagens genéricas como `update` ou `alterações` não são aceitas.

### Pull requests

1. Nada entra na `main` sem pull request.
2. Todo pull request precisa da revisão e aprovação de **outro** integrante antes do merge.
3. O pull request referencia a issue da tarefa (ex.: `Closes #23`), para que ela seja fechada automaticamente no merge.
4. Antes de pedir revisão, o autor confirma que `dotnet build` e `dotnet test` passam.

## Documentação

- [Enunciado do trabalho](docs/enunciado.md)
- [Product Backlog](docs/product-backlog.md)
- Planejamento e retrospectiva: [Sprint 1](docs/sprints/sprint-1.md) · [Sprint 2](docs/sprints/sprint-2.md) · [Sprint 3](docs/sprints/sprint-3.md) · [Sprint 4](docs/sprints/sprint-4.md)
- [Quadro do projeto](https://github.com/users/ItalloOtavio/projects/11)
