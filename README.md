# UrbanDrive
Sistema de Gestão de Mobilidade Urbana

1. Tema do projeto
O UrbanDrive é um sistema de gerenciamento para empresas de transporte multimodal, envolvendo aluguel de veículos, patinetes elétricos e gestão de frotas corporativas.

O sistema deverá permitir o gerenciamento de diferentes tipos de veículos, usuários, motoristas e frotas, além de implementar regras de negócio relacionadas à locação, aos custos e à manutenção dos veículos.

O projeto foi escolhido por possibilitar a aplicação prática dos principais conceitos da Programação Orientada a Objetos (POO), incluindo encapsulamento, tipos abstratos de dados (TAD), relacionamentos entre objetos, membros estáticos, herança, polimorfismo, abstração e interfaces.

O desenvolvimento será realizado em C#, utilizando uma aplicação de console, e deverá ser organizado em um repositório GitHub compartilhado pelos integrantes do grupo.

Diferentemente de um roteiro tradicional de implementação, este trabalho exige que os grupos planejem as sprints, definam suas tarefas, distribuam responsabilidades e acompanhem a evolução do produto.

O professor estabelecerá os requisitos e os resultados mínimos esperados. Cada grupo será responsável por decidir como organizar o trabalho para atingir esses resultados.

2. Objetivos de aprendizagem
Ao concluir o trabalho, espera-se que os estudantes sejam capazes de:

Modelar um problema utilizando os princípios da Programação Orientada a Objetos.

Implementar classes, objetos, propriedades, construtores e mecanismos de encapsulamento.

Representar relacionamentos de associação, agregação e composição.

Utilizar membros estáticos para gerenciar informações compartilhadas.

Aplicar herança, sobrescrita de métodos, sobrecarga e polimorfismo.

Diferenciar classes concretas, classes abstratas e interfaces.

Implementar contratos de comportamento por meio de interfaces.

Organizar um projeto C# com separação de responsabilidades.

Elaborar e executar o planejamento de sprints.

Decompor requisitos em tarefas, estimar esforços e distribuir responsabilidades.

Utilizar Git e GitHub para versionamento e colaboração.

Demonstrar a evolução incremental de um produto de software.

3. Visão geral do sistema
O UrbanDrive deverá contemplar o gerenciamento de diferentes tipos de veículos e suas operações.

3.1. Entidades e componentes previstos
O projeto deverá considerar, no mínimo, os seguintes elementos:

Veiculo: representação geral de um veículo.

Carro: especialização de Veiculo.

Patinete: especialização de Veiculo.

Motorista: representação de um motorista ou usuário autorizado.

CNH: representação da Carteira Nacional de Habilitação.

Frota: agrupamento de veículos administrados pelo sistema.

ConfiguradorSistema: componente responsável por informações compartilhadas, como taxas ou contadores.

Locação: representação de uma operação de aluguel de veículo.

CarroEletrico: especialização de carro com funcionalidades relacionadas à recarga elétrica.

Os grupos poderão propor outros componentes quando julgarem necessário, desde que justifiquem suas decisões de projeto.

3.2. Requisitos funcionais mínimos
O sistema deverá contemplar os seguintes requisitos:

RF01 — Gerenciamento de veículos

Permitir a representação e o gerenciamento de veículos, considerando identificador, placa, modelo e valor-base da diária.

RF02 — Especialização de veículos

Permitir a representação de diferentes categorias de veículos, incluindo carros e patinetes, com características próprias.

RF03 — Gerenciamento de motoristas

Representar motoristas e suas respectivas CNHs, respeitando as regras de relacionamento entre esses objetos.

RF04 — Gerenciamento de frotas

Permitir agrupar e gerenciar veículos em uma frota.

RF05 — Cálculo de locação

Calcular o custo de locação de acordo com o tipo de veículo e as regras de negócio implementadas.

RF06 — Manutenção de veículos

Representar operações de manutenção, incluindo a possibilidade de informar uma peça substituída.

RF07 — Configuração do sistema

Permitir a utilização de informações compartilhadas, como taxas de cálculo ou contadores de veículos.

RF08 — Relatórios

Permitir gerar representações textuais ou relatórios das entidades por meio de um contrato comum de comportamento.

RF09 — Recursos elétricos

Representar os veículos elétricos e suas operações de recarga, respeitando os comportamentos definidos para cada tipo.

RF10 — Consulta e apresentação

Disponibilizar, por meio da aplicação de console, opções para cadastrar e consultar veículos e demonstrar seus comportamentos.

Os grupos deverão analisar esses requisitos, identificar eventuais dependências e transformá-los em itens de um Product Backlog.

O professor poderá esclarecer dúvidas sobre os requisitos, mas a decomposição em tarefas, a estimativa de esforço e a distribuição do trabalho serão responsabilidades dos grupos.

4. Organização do desenvolvimento em sprints
O desenvolvimento será organizado em quatro sprints, acompanhando a evolução dos conhecimentos de POO trabalhados nas aulas práticas.

Cada sprint deverá possuir um objetivo, um planejamento, atividades de desenvolvimento e testes, um incremento demonstrável e uma avaliação dos resultados.

Atenção: os conteúdos indicados para cada sprint representam marcos mínimos de aprendizagem. Eles não constituem uma lista de tarefas pronta para ser executada. Cabe a cada grupo elaborar seu próprio planejamento para alcançar os resultados esperados.

4.1. Sprint 1 — Modelagem inicial e encapsulamento
Desafio: estabelecer a estrutura inicial do sistema e implementar uma primeira versão funcional.

O grupo deverá analisar os requisitos, organizar o Product Backlog e decidir quais atividades são necessárias para iniciar o desenvolvimento.

A solução deverá contemplar:

Criação do projeto C# e configuração do repositório GitHub.

Modelagem inicial das entidades.

Implementação da classe Veiculo, considerando os atributos identificador, placa, modelo e valor-base da diária.

Utilização de atributos privados e propriedades públicas.

Implementação de construtores.

Validação dos dados, incluindo a restrição de placa nula ou vazia.

Instanciação de objetos e realização de testes iniciais.

Planejamento obrigatório

O grupo deverá definir:

O objetivo da sprint.

Os itens do backlog selecionados.

As tarefas necessárias para realizar o trabalho.

Os responsáveis e as estimativas de esforço.

Os critérios utilizados para verificar a conclusão.

O incremento que será apresentado ao final da sprint.

Entregáveis da Sprint 1

Product Backlog inicial, priorizado.

Documento de planejamento da Sprint 1.

Código-fonte da versão implementada.

Demonstração da criação de objetos e da validação das propriedades.

Evidências de testes realizados.

Registro do resultado da sprint, incluindo pendências e dificuldades.

Resultado mínimo esperado: uma primeira versão executável que represente veículos e demonstre o funcionamento do encapsulamento e das validações.

4.2. Sprint 2 — Relacionamentos entre objetos e membros estáticos
Desafio: ampliar o modelo para representar a interação entre os componentes do sistema.

O grupo deverá atualizar o backlog com base nos resultados anteriores e planejar a implementação dos relacionamentos e dos recursos compartilhados.

A solução deverá contemplar:

Associação entre objetos, quando pertinente.

Composição entre Motorista e CNH, considerando que a CNH não deverá existir de forma independente do motorista no modelo proposto.

Agregação entre Frota e Veiculo, permitindo que uma frota gerencie uma coleção de veículos.

Utilização de membros estáticos.

Implementação de um componente ConfiguradorSistema para gerenciar uma informação compartilhada.

Atualização do diagrama de classes para representar as relações implementadas.

Planejamento obrigatório

O grupo deverá justificar como os novos componentes se relacionam com a estrutura existente, quais atividades precisam ser realizadas e como será testada a integração entre os objetos.

Entregáveis da Sprint 2

Planejamento da Sprint 2.

Product Backlog atualizado.

Diagrama de classes atualizado.

Código-fonte com os relacionamentos implementados.

Demonstração da interação entre os objetos.

Evidências de testes dos relacionamentos e dos membros estáticos.

Registro das atividades concluídas e das pendências.

Resultado mínimo esperado: uma versão executável que represente os relacionamentos entre os componentes e demonstre o funcionamento dos membros estáticos.

4.3. Sprint 3 — Herança, polimorfismo e especialização
Desafio: implementar diferentes comportamentos para as categorias de veículos, evitando duplicação desnecessária de código.

A solução deverá contemplar:

Criação da classe Carro, herdando de Veiculo.

Criação da classe Patinete, herdando de Veiculo.

Inclusão de características específicas, como quantidade de portas e autonomia da bateria.

Implementação do método CalcularAluguel(int dias).

Sobrescrita do método de cálculo de aluguel para representar comportamentos diferentes entre carros e patinetes.

Utilização de sobrecarga por meio dos métodos RealizarManutencao() e RealizarManutencao(string pecaSubstituida).

Utilização de classes seladas, tornando Patinete uma classe sealed.

Utilização adequada de construtores e do mecanismo base para inicialização da classe-base.

Planejamento obrigatório

O grupo deverá organizar as tarefas necessárias para implementar e testar os comportamentos especializados, justificando como evitará duplicação de código e como demonstrará o polimorfismo.

Entregáveis da Sprint 3

Planejamento da Sprint 3.

Product Backlog atualizado.

Diagrama de classes atualizado.

Código-fonte com a hierarquia de veículos implementada.

Demonstração dos diferentes cálculos de locação.

Demonstração da sobrecarga de métodos de manutenção.

Evidências de testes dos comportamentos especializados.

Registro das atividades concluídas e das pendências.

Resultado mínimo esperado: uma versão executável que demonstre a utilização de herança, sobrescrita, sobrecarga e polimorfismo.

4.4. Sprint 4 — Abstração, interfaces e consolidação do sistema
Desafio: consolidar a arquitetura e concluir uma versão integrada do UrbanDrive.

A solução deverá contemplar:

Transformação de Veiculo em uma classe abstrata.

Implementação da interface IImprimivel, contendo o método GerarRelatorio().

Implementação de IImprimivel pelas entidades selecionadas pelo grupo, respeitando os contratos definidos.

Implementação da interface IEletrico, contendo o método Recarregar().

Aplicação de IEletrico aos veículos elétricos, incluindo Patinete e CarroEletrico.

Integração dos componentes implementados nas sprints anteriores.

Disponibilização das operações de cadastro e consulta de veículos na aplicação de console.

Demonstração dos cálculos polimórficos.

Execução dos testes finais.

Planejamento obrigatório

O grupo deverá priorizar as atividades necessárias para concluir o produto, tratar as pendências e definir como verificará o atendimento aos requisitos.

Entregáveis da Sprint 4

Planejamento da Sprint 4.

Product Backlog atualizado.

Diagrama de classes final.

Código-fonte integrado.

Aplicação executável.

Evidências de testes finais.

Documentação de instalação e execução.

Apresentação demonstrando o funcionamento do sistema.

Relatório final com a evolução das sprints, as principais decisões e as dificuldades encontradas.

Resultado mínimo esperado: uma versão integrada e executável do UrbanDrive, demonstrando os conceitos de POO exigidos no trabalho.

5. Como elaborar o planejamento de cada sprint
Cada grupo deverá produzir um documento de planejamento para cada sprint.

Não basta listar as funcionalidades que pretende implementar. O planejamento deverá demonstrar como o grupo pretende alcançar o objetivo estabelecido.

Cada documento deverá conter os seguintes elementos.

5.1. Identificação e objetivo

Informar o número da sprint, o período previsto e seu objetivo.

O objetivo deverá indicar o resultado que se pretende alcançar, e não apenas listar atividades.

5.2. Seleção dos itens do backlog

Apresentar os requisitos ou itens do Product Backlog selecionados para a sprint.

O grupo deverá justificar a seleção, considerando a prioridade, as dependências, os conhecimentos necessários e o esforço estimado.

5.3. Decomposição em tarefas

Transformar os itens selecionados em tarefas específicas que possam ser executadas e acompanhadas.

Por exemplo, um requisito de cadastro pode exigir modelagem da entidade, implementação das validações, desenvolvimento da funcionalidade e execução de testes.

Esse exemplo é apenas ilustrativo. O grupo deverá identificar as tarefas adequadas ao seu próprio planejamento.

5.4. Responsáveis e estimativas

Cada tarefa deverá possuir um responsável ou responsáveis definidos, além de uma estimativa de esforço.

As estimativas devem ser justificáveis e compatíveis com o tempo disponível e com a experiência dos integrantes.

5.5. Critérios de aceitação

Para cada funcionalidade relevante, o grupo deverá definir condições objetivas que permitam verificar se o resultado atende ao requisito.

Não será suficiente afirmar que uma funcionalidade está pronta porque o código foi escrito ou porque o projeto compila.

5.6. Entregáveis e evidências

O grupo deverá informar o que estará efetivamente disponível ao final da sprint e como demonstrará o resultado.

As evidências poderão incluir demonstrações da aplicação, testes executados, código-fonte, diagramas e registros do repositório.

5.7. Acompanhamento e retrospectiva

Ao final da sprint, o grupo deverá registrar:

O que foi planejado.

O que foi efetivamente concluído.

O que permaneceu pendente.

Quais dificuldades foram encontradas.

Quais decisões precisaram ser revistas.

O que deverá ser melhorado na sprint seguinte.

O planejamento não deverá ser alterado retroativamente para ocultar diferenças entre o que foi previsto e o que foi realizado. Eventuais mudanças deverão ser registradas e justificadas.

6. Modelo de documento para o planejamento das sprints
O grupo deverá utilizar o seguinte modelo em todas as sprints.

A. Identificação
Grupo:

Integrantes:

Número da sprint:

Período:

Responsável pelo acompanhamento:

B. Objetivo da sprint
Descrever o resultado que o grupo pretende alcançar.

C. Itens selecionados do Product Backlog
ID	Requisito ou item	Prioridade	Justificativa
D. Planejamento das tarefas
ID	Tarefa	Item relacionado	Responsável	Estimativa de esforço
O grupo deverá definir a unidade utilizada nas estimativas e mantê-la consistente.

E. Critérios de aceitação
Para cada item selecionado, indicar as condições que deverão ser atendidas para considerar a funcionalidade concluída.

F. Entregáveis previstos
Descrever as funcionalidades, os incrementos, os testes e as evidências que deverão estar disponíveis ao final da sprint.

G. Resultado da sprint
Item ou tarefa	Situação	Evidência	Observações
Utilizar situações como concluído, parcialmente concluído ou não concluído, de acordo com o resultado real.

H. Retrospectiva
Responder às seguintes perguntas:

O que funcionou bem?

Quais foram as principais dificuldades?

O planejamento foi adequado ao esforço necessário?

O que deverá ser melhorado na próxima sprint?

7. GitHub e versionamento
O projeto deverá ser desenvolvido em um repositório GitHub compartilhado pelos integrantes do grupo.

7.1. Organização do repositório
O repositório deverá conter:

Código-fonte do projeto.

Documentação técnica.

Diagramas de classes.

Planejamento das quatro sprints.

Registros das retrospectivas.

Evidências das entregas, quando aplicável.

Os documentos de planejamento deverão ser versionados no repositório, permitindo acompanhar sua evolução.

7.2. Padrão de commits
Os commits deverão utilizar o padrão Conventional Commits, com mensagens claras e representativas das alterações.

Exemplos:

feat: implementa validacao da placa

fix: corrige calculo de aluguel

docs: atualiza diagrama de classes

refactor: reorganiza gerenciamento da frota

test: adiciona testes para calculo de locacao

Commits genéricos, como update, alterações ou trabalho, não serão considerados evidências suficientes de uma contribuição bem documentada.

7.3. Branches e colaboração
A branch main deverá manter uma versão estável do projeto.

Os integrantes deverão utilizar branches para desenvolver suas tarefas, integrando as alterações ao projeto após a verificação correspondente.

Exemplos:

feature/cadastro-veiculos

feature/calculo-locacao

fix/validacao-cnh

docs/planejamento-sprint-2

7.4. Participação individual
Cada integrante deverá apresentar contribuições identificáveis no repositório.

A participação será avaliada considerando os commits, as alterações implementadas, as tarefas assumidas e as evidências de colaboração.

A ausência de contribuições registradas poderá resultar em redução da nota individual, conforme os critérios de avaliação e a verificação do professor. A existência de commits, isoladamente, não comprova a qualidade ou a autoria efetiva de toda a contribuição.

8. Estrutura sugerida do projeto
O grupo deverá organizar o código de maneira coerente, evitando concentrar toda a lógica de negócio na classe Program.cs.

Uma estrutura possível é:

UrbanDrive/

├── src/

│ ├── UrbanDrive.Models/

│ │ ├── Entities/

│ │ ├── Interfaces/

│ │ └── Enums/

│ ├── UrbanDrive.Services/

│ └── UrbanDrive.App/

│ └── Program.cs

├── docs/

│ ├── diagramas/

│ ├── sprints/

│ └── README.md

├── tests/

├── .gitignore

└── README.md

Essa estrutura é uma sugestão, e não uma exigência de reprodução literal. O grupo poderá propor outra organização, desde que mantenha uma separação adequada de responsabilidades e justifique suas decisões.

9. Critérios de avaliação
A avaliação considerará tanto o produto desenvolvido quanto a capacidade do grupo de planejar, executar e acompanhar o trabalho.

Critério	Peso	Descrição de sucesso
Planejamento e acompanhamento das sprints	25%	Objetivos claros, backlog priorizado, tarefas específicas, estimativas justificáveis, critérios de aceitação e registros de execução e retrospectiva.
Arquitetura e conceitos de POO	30%	Utilização correta de encapsulamento, relacionamentos, membros estáticos, herança, polimorfismo, abstração e interfaces.
Funcionalidade e qualidade dos testes	20%	Sistema executável, regras de negócio implementadas, cálculos corretos e evidências de testes adequados.
Versionamento e colaboração	10%	Histórico consistente, contribuições identificáveis, branches adequadas e mensagens de commit significativas.
Organização, documentação e apresentação	15%	Código organizado, documentação suficiente, diagramas coerentes e demonstração clara dos resultados.
Total	100%	
9.1. Aspectos que poderão reduzir a avaliação
Planejamento genérico, sem tarefas específicas ou critérios verificáveis.

Entregáveis que não correspondem ao objetivo declarado.

Ausência de registro das atividades não concluídas.

Uso incorreto de herança, interfaces ou encapsulamento.

Duplicação desnecessária de código.

Erros de compilação ou regras de negócio que não funcionam.

Ausência de testes para comportamentos relevantes.

Commits sem descrição adequada ou ausência de contribuições individuais comprováveis.

Código desorganizado e concentração indevida de responsabilidades na aplicação de console.

Documentação que não corresponde ao estado real do projeto.

Os problemas deverão ser avaliados conforme sua gravidade e seu impacto nos requisitos do trabalho.

10. Entrega final e apresentação
Ao final da quarta sprint, cada grupo deverá apresentar:

O sistema UrbanDrive executável.

O código-fonte completo no GitHub.

Os documentos de planejamento das quatro sprints.

O Product Backlog e seu histórico de evolução.

Os diagramas de classes atualizados.

As evidências de testes.

O registro das retrospectivas.

A documentação necessária para executar o projeto.

Uma demonstração das principais funcionalidades e dos conceitos de POO implementados.

Durante a apresentação, o professor poderá solicitar que os integrantes expliquem decisões de projeto, demonstrem comportamentos específicos e justifiquem a distribuição das tarefas.

Cada integrante deverá ser capaz de explicar as contribuições pelas quais foi responsável.

11. Orientações finais
O objetivo deste trabalho não é apenas implementar um sistema que funcione, mas desenvolver a capacidade de organizar e acompanhar a construção de um produto de software.

Os grupos deverão demonstrar que conseguem transformar requisitos em itens de backlog, planejar tarefas, distribuir responsabilidades, produzir incrementos funcionais e avaliar os resultados alcançados.

O planejamento é uma atividade contínua. As decisões tomadas no início do projeto poderão ser revistas à medida que os grupos adquirirem experiência e identificarem novas necessidades.

Não será exigido que todas as estimativas se confirmem exatamente ou que todas as sprints transcorram sem dificuldades. Será avaliada a capacidade de identificar problemas, justificar decisões e melhorar o processo de desenvolvimento.

Integridade acadêmica: o código deverá ser produzido pelos integrantes do grupo, com indicação das fontes externas utilizadas quando aplicável. A reprodução indevida de soluções de outros grupos será tratada conforme as regras de integridade acadêmica da disciplina.
