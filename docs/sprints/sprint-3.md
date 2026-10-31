# Sprint 3 — Herança, polimorfismo e especialização

### Criar a classe Carro
Implementar `Carro` herdando de `Veiculo`, com a quantidade de portas, usando `: base(...)` no construtor para reaproveitar a inicialização e as validações de `Veiculo`.

### Criar a classe Patinete
Implementar `Patinete` como `sealed`, herdando de `Veiculo`, com a autonomia da bateria, também usando `: base(...)`.

### Implementar o cálculo de aluguel
Criar `CalcularAluguel(int dias)` como `virtual` em `Veiculo` (diária × dias, rejeitando dias ≤ 0) e sobrescrever com `override` em `Carro` (somando a taxa de seguro do `ConfiguradorSistema`) e em `Patinete` (com regra própria, como desconto para locações longas).

### Implementar a manutenção com sobrecarga
Criar em `Veiculo` os métodos `RealizarManutencao()` (manutenção geral) e `RealizarManutencao(string pecaSubstituida)` (registrando a peça trocada).

### Testar herança, sobrescrita e sobrecarga
Testar se cada tipo calcula o aluguel com o valor esperado, se uma variável do tipo `Veiculo` usa a regra do tipo real (polimorfismo) e se as duas versões da manutenção funcionam.

### Demonstrar o polimorfismo no console
Percorrer a frota com carros e patinetes em um único laço chamando `CalcularAluguel` e mostrar os valores diferentes. Demonstrar também as duas formas de manutenção.

### Atualizar o diagrama de classes
Incluir `Carro` e `Patinete` com a relação de herança e os métodos sobrescritos.
