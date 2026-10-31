# Sprint 4 — Abstração, interfaces e consolidação do sistema

### Tornar Veiculo abstrata
Transformar `Veiculo` em classe `abstract` e ajustar o código e os testes que criavam `Veiculo` diretamente.

### Criar a interface IImprimivel
Criar `IImprimivel` com o método `GerarRelatorio()` e implementar nas entidades escolhidas pelo grupo (ex.: veículos, Motorista, Frota e Locacao).

### Criar a interface IEletrico
Criar `IEletrico` com o método `Recarregar()` e aplicar em `Patinete`.

### Criar a classe CarroEletrico
Implementar `CarroEletrico` herdando de `Carro` e implementando `IEletrico`, com nível de bateria e recarga.

### Criar o menu do console
Montar um menu para cadastrar e consultar veículos, listar a frota, simular locação, realizar manutenção, recarregar elétricos e gerar relatórios. Entradas inválidas devem mostrar mensagem e voltar ao menu. O `Program.cs` só cuida da tela, sem regras de negócio.

### Resolver pendências das sprints anteriores
Levantar e corrigir o que ficou incompleto nas sprints 1, 2 e 3.

### Executar os testes finais
Completar os testes de abstração, interfaces e integração (frota + locação + cálculo) e garantir que todos passam.

### Finalizar o diagrama de classes
Atualizar o diagrama com a classe abstrata, as interfaces e `CarroEletrico`.

### Escrever a documentação
Atualizar o README com instruções de instalação e execução e escrever o relatório final com a evolução das sprints, as decisões e as dificuldades.

### Preparar a apresentação
Montar a apresentação e o roteiro da demonstração do sistema e dos conceitos de POO.
