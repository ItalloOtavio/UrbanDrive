# Sprint 2 — Relacionamentos entre objetos e membros estáticos

### Criar a classe CNH
Implementar `CNH` com número, categoria e data de validade, e um método `EstaValida()` que diga se a CNH está vencida.

### Criar a classe Motorista com composição
Implementar `Motorista` (nome, CPF) criando a `CNH` dentro do próprio construtor, de forma que a CNH não exista sem o motorista e não possa ser trocada por fora.

### Criar a classe Frota com agregação
Implementar `Frota` com uma lista de veículos e os métodos para adicionar, remover, buscar por placa e listar. Não permitir placa repetida. Os veículos devem continuar existindo mesmo se forem removidos da frota.

### Criar o ConfiguradorSistema
Implementar `ConfiguradorSistema` com membros estáticos: uma taxa de seguro (que não aceita valor negativo) e um contador de veículos criados. O construtor de `Veiculo` deve incrementar esse contador.

### Criar a classe Locacao com associação
Implementar `Locacao` ligando um `Motorista` a um `Veiculo` com a quantidade de dias. Rejeitar dias ≤ 0 e motorista com CNH vencida.

### Testar os relacionamentos e os membros estáticos
Testar a composição (motorista sempre tem CNH), a agregação (placa repetida, busca, remoção), o contador estático e as regras da locação.

### Demonstrar a interação no console
Mostrar no console um motorista com CNH, uma frota com veículos, o contador de veículos e uma locação sendo criada.

### Atualizar o diagrama de classes
Incluir CNH, Motorista, Frota, ConfiguradorSistema e Locacao, indicando composição, agregação e associação.
