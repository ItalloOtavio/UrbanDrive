# Relatório Final — Projeto UrbanDrive

**Disciplina:** Programação Orientada a Objetos  
**Instituição:** Pontifícia Universidade Católica de Minas Gerais (PUC Minas)  
**Integrantes:** Itallo Otavio, Manuela Souza, Alexandre Martins, Wagner Teofilo e Maria Eduarda  
**Repositório:** [ItalloOtavio/UrbanDrive](https://github.com/ItalloOtavio/UrbanDrive)

---

## 1. Visão Geral do Sistema

O **UrbanDrive** é um sistema de gestão de mobilidade urbana voltado para empresas de transporte multimodal, permitindo o cadastro e controlo de frotas corporativas (carros convencionais, carros elétricos e patinetes elétricos), gestão de motoristas e CNHs, controlo de manutenções, recarga de veículos elétricos e cálculo automatizado de locações.

A solução foi arquitetada em C# (.NET 10) dividida em três projetos desacoplados:
- **`UrbanDrive.Models`**: camada de domínio contendo entidades, abstrações, interfaces e regras de negócio.
- **`UrbanDrive.App`**: interface interativa de consola para operação do sistema pelo utilizador.
- **`UrbanDrive.Tests`**: suíte automatizada de testes unitários e de integração desenvolvida com **xUnit**.

---

## 2. Evolução das Sprints

O desenvolvimento ocorreu de forma incremental ao longo de quatro sprints, aplicando progressivamente os pilares da Programação Orientada a Objetos:

### Sprint 1 — Modelagem Inicial e Encapsulamento
- **Entregas:** Criação da solução `.NET`, configuração do `.gitignore`, modelagem inicial da entidade `Veiculo` e definição dos diagramas de classes UML.
- **Conceitos aplicados:** Encapsulamento de atributos privados com propriedades públicas (`Id`, `Placa`, `Modelo`, `ValorBaseDiaria`), construtores parametrizados e validações defensivas lançando exceções específicas (`ArgumentException`, `ArgumentOutOfRangeException`).

### Sprint 2 — Relacionamentos entre Objetos e Membros Estáticos
- **Entregas:** Implementação de `Motorista`, `CNH`, `Frota`, `Locacao` e `ConfiguradorSistema`.
- **Conceitos aplicados:**
  - **Composição:** `Motorista` cria e gere o ciclo de vida da sua própria `CNH`, impedindo locações com habilitação vencida (`EstaValida()`).
  - **Agregação:** `Frota` mantém uma coleção de veículos existentes sem destruir os seus ciclos de vida individuais, bloqueando placas duplicadas.
  - **Associação:** `Locacao` liga um `Motorista` válido a um `Veiculo` por um período determinado.
  - **Membros Estáticos (`static`):** `ConfiguradorSistema` centraliza a `TaxaSeguro` global e o contador de veículos criados.

### Sprint 3 — Herança, Polimorfismo e Especialização
- **Entregas:** Criação das subclasses `Carro` e `Patinete`, implementação de cálculo polimórfico de aluguer e sobrecarga de manutenção.
- **Conceitos aplicados:**
  - **Herança e Sobrescrita (`virtual` / `override`):** `Carro` sobrescreve `CalcularAluguel(int dias)` somando a taxa diária de seguro (`ConfiguradorSistema.TaxaSeguro * dias`); `Patinete` sobrescreve o mesmo método aplicando **10% de desconto** em locações de 7 dias ou mais.
  - **Classe Selada (`sealed`):** `Patinete` foi marcada como `sealed` para impedir especializações indevidas na hierarquia.
  - **Sobrecarga de Métodos:** `Veiculo` disponibiliza `RealizarManutencao()` (manutenção geral) e `RealizarManutencao(string pecaSubstituida)` (registo com peça trocada), mantendo histórico interno encapsulado.

### Sprint 4 — Abstração, Interfaces e Consolidação
- **Entregas:** Conversão de `Veiculo` em classe abstrata, criação das interfaces `IEletrico` e `IImprimivel`, implementação de `CarroEletrico`, menu interativo na consola (`MenuConsole` / `LeitorConsole`) e testes finais de integração.
- **Conceitos aplicados:**
  - **Abstração:** `Veiculo` tornou-se `abstract` com construtor `protected`, impedindo instâncias genéricas e obrigando o uso de tipos concretos (`Carro`, `CarroEletrico`, `Patinete`).
  - **Interfaces (Contratos):**
    - `IEletrico`: implementada por `CarroEletrico` e `Patinete`, padronizando o método `Recarregar()` e o controlo de `NivelBateria` (0% a 100%).
    - `IImprimivel`: implementada por `Veiculo` (e sobrescrita nas subclasses) e `Locacao`, unificando a emissão de relatórios via `GerarRelatorio()`.

---

## 3. Principais Decisões Arquiteturais e de Processo

1. **Separação entre Domínio e Interface (`UrbanDrive.Models` vs `UrbanDrive.App`):** Manter todas as regras de negócio e validações na biblioteca de classes permitiu testar todo o núcleo do sistema de forma isolada e automatizada com xUnit, sem depender de entradas manuais via `Console.ReadLine()`.
2. **Validação Antecipada (Fail-Fast):** Todas as entidades validam invariantes nos construtores e *setters* (ex.: nível de bateria entre 0 e 100, CNH válida no ato da locação, valores positivos para diárias e dias), evitando estados inconsistentes em memória.
3. **Fluxo Git Colaborativo com Revisão Obrigatória:** Adoção de branches dedicadas por issue (`feature/`, `test/`, `docs/`), mensagens padronizadas via *Conventional Commits* e exigência de aprovação de pelo menos um colega em cada Pull Request antes do merge na `main`.

---

## 4. Dificuldades Encontradas e Soluções

- **Conflitos e atualizações de base em Pull Requests encadeados:** Quando tarefas dependentes eram desenvolvidas em paralelo (como a implementação de um método na classe base e os seus respetivos testes unitários), o merge de um PR alterava a base da `main` e invalidava aprovações pendentes (*stale reviews*). **Solução:** Sincronização frequente com `git pull origin main` antes de abrir novas branches e revalidação rápida dos diffs nos PRs dependentes.
- **Evolução de `Veiculo` para classe abstrata na Sprint 4:** Ao transformar `Veiculo` em `abstract`, testes unitários criados nas Sprints 1 e 3 que instanciavam `new Veiculo(...)` diretamente precisaram de ser adaptados. **Solução:** Refatoração dos testes antigos para utilizar subclasses concretas (`Carro` e `Patinete`) e criação de testes de reflexão (`typeof(Veiculo).IsAbstract`) garantindo o contrato de abstração.
- **Bloqueios de política local do Windows em pastas sincronizadas:** Em ambientes Windows 11 com Controlo Inteligente de Aplicações ativo, a execução local de DLLs de teste dentro da pasta `Desktop` sofreu bloqueio (`0x800711C7`) após a compilação. **Solução:** Execução dos testes em diretório raiz dedicado (`C:\Dev`) e validação contínua da compilação antes de cada submissão.
