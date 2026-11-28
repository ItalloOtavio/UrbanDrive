# UrbanDrive

Sistema de gestão de mobilidade urbana para empresas de transporte multimodal: aluguel de veículos, patinetes elétricos e gestão de frotas corporativas.

Projeto da disciplina de Programação Orientada a Objetos (PUC Minas), desenvolvido em **C# (.NET 10)** como aplicação de console e organizado em quatro sprints. O enunciado completo está em [docs/enunciado.md](docs/enunciado.md).

## Sumário

- [Equipe](#equipe)
- [Andamento das sprints](#andamento-das-sprints)
- [Requisitos](#requisitos)
- [Estrutura do repositório](#estrutura-do-repositório)
- [Instalação e execução](#instalação-e-execução)
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
| 1 | Modelagem inicial e encapsulamento | Classes, propriedades, construtores, validação | [sprint-1.md](docs/sprints/sprint-1.md) | Concluída |
| 2 | Relacionamentos entre objetos e membros estáticos | Associação, agregação, composição, `static` | [sprint-2.md](docs/sprints/sprint-2.md) | Concluída |
| 3 | Herança, polimorfismo e especialização | Herança, `override`, sobrecarga, `sealed` | [sprint-3.md](docs/sprints/sprint-3.md) | Concluída |
| 4 | Abstração, interfaces e consolidação | Classes abstratas, interfaces (`IEletrico`, `IImprimivel`) | [sprint-4.md](docs/sprints/sprint-4.md) | Concluída |

## Requisitos

| ID | Requisito | Sprint | Status |
|---|---|---|---|
| RF01 | Gerenciamento de veículos (identificador, placa, modelo e valor da diária) | 1 | Implementado |
| RF02 | Especialização de veículos (`Carro`, `Patinete` e `CarroEletrico`) | 3 e 4 | Implementado |
| RF03 | Gerenciamento de motoristas e CNHs | 2 | Implementado |
| RF04 | Gerenciamento de frotas | 2 | Implementado |
| RF05 | Cálculo de locação conforme o tipo de veículo | 2 e 3 | Implementado |
| RF06 | Manutenção de veículos, com peça substituída opcional | 3 | Implementado |
| RF07 | Configuração do sistema (taxas e contadores compartilhados) | 2 | Implementado |
| RF08 | Relatórios por meio de um contrato comum (`IImprimivel`) | 4 | Implementado |
| RF09 | Veículos elétricos e recarga (`IEletrico`) | 4 | Implementado |
| RF10 | Cadastro e consulta pela aplicação de console | 4 | Implementado |

A priorização e as dependências entre os itens estão no [Product Backlog](docs/product-backlog.md).

## Estrutura do repositório

```text
UrbanDrive/
├── src/
│   ├── UrbanDrive.Models/   # entidades, interfaces, abstracoes e regras de negocio
│   ├── UrbanDrive.App/      # aplicacao de console interativa (Program.cs, MenuConsole.cs)
│   └── UrbanDrive.Tests/    # suite de testes unitarios e de integracao (xUnit)
├── docs/
│   ├── enunciado.md         # enunciado do trabalho
│   ├── product-backlog.md   # backlog priorizado e seu historico
│   ├── relatorio-final.md   # relatorio final com evolucao, decisoes e dificuldades
│   ├── sprints/             # planejamento, resultado e retrospectiva de cada sprint
│   ├── diagramas/           # diagramas de classes UML
│   └── evidencias/          # saidas de testes e capturas de tela
├── UrbanDrive.slnx          # solucao C#
├── .gitignore
└── README.md