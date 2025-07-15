# Banco de dados.


## Altere essa linha de acordo com sua realizade.
```
private static readonly string conexaoString =
            "server = localhost; uid = root; pwd = r00t; database = Fazenda";
```

```
 CREATE DATABASE Fazenda;

 
USE fazenda;

-- -------- Tabela: Raca --------
CREATE TABLE Raca (
  id_raca INT PRIMARY KEY AUTO_INCREMENT,
  nome_raca VARCHAR(100) NOT NULL,
  descricao_raca TEXT,
  codigo_raca VARCHAR(10) NOT NULL UNIQUE
);


-- -------- Tabela: Tipo_animal --------
CREATE TABLE Tipo_animal (
  id_tpAnimal INT PRIMARY KEY AUTO_INCREMENT,
  nome VARCHAR(100) NOT NULL,
  idade_minima_meses INT NOT NULL,
  idade_maxima_meses INT
);


-- -------- Tabela: Cliente --------
CREATE TABLE Cliente (
  id_cliente INT PRIMARY KEY AUTO_INCREMENT,
  nome VARCHAR(255) NOT NULL,
  cpf_cnpj VARCHAR(18)  NOT NULL UNIQUE,
  data_cadastro DATE NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  email VARCHAR(255),
  endereco VARCHAR(255) NOT NULL,
  cidade VARCHAR(100) NOT NULL,
  estado VARCHAR(2) NOT NULL,
  incricao_estatual VARCHAR(50),
  tipo_cliente VARCHAR(20) NOT NULL, -- Ex: 'FÍSICA', 'JURÍDICA'
  status_cliente VARCHAR(20)
);


-- -------- Tabela: Funcionario --------
CREATE TABLE Funcionario (
  id_funcionario INT PRIMARY KEY AUTO_INCREMENT,
  nome_fun VARCHAR(255) NOT NULL,
  cpf VARCHAR(14) NOT NULL UNIQUE,
  data_nascimento DATE,
  sexo VARCHAR(20), -- Ex: 'MASCULINO', 'FEMININO'
  endereco VARCHAR(255) NOT NULL,
  cidade VARCHAR(100) NOT NULL,
  estado VARCHAR(2) NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  email VARCHAR(255),
  data_admissao DATE NOT NULL,
  cargo VARCHAR(100),
  salario DOUBLE,
  status_funcionario  VARCHAR(20) NOT NULL,
  tipo_contrato VARCHAR(50) NOT NULL
);

-- -------- Tabela: Pasto --------
CREATE TABLE Pasto (
  id_pasto INT PRIMARY KEY AUTO_INCREMENT,
  descricao VARCHAR(255),
  localizacao VARCHAR(255) NOT NULL,
  tamanho DOUBLE NOT NULL,
  unidade_medida VARCHAR(20) NOT NULL,
  tipo_pastagem VARCHAR(100)
);

-- -------- Tabela: Fornecedor --------
CREATE TABLE Fornecedor (
  id_fornecedor INT PRIMARY KEY AUTO_INCREMENT,
  razao_social VARCHAR(255) NOT NULL,
  cpf_cnpj VARCHAR(18) NOT NULL UNIQUE,
  telefone VARCHAR(20) NOT NULL,
  email VARCHAR(255),
  endereco VARCHAR(255) NOT NULL,
  cidade VARCHAR(100) NOT NULL,
  estado VARCHAR(2) NOT NULL
);

-- -------- Tabela: suplemento_medicamento --------
CREATE TABLE suplemento_medicamento (
  id_insumo INT PRIMARY KEY AUTO_INCREMENT,
  nome VARCHAR(255) NOT NULL,
  descricao TEXT,
  categoria VARCHAR(100) NOT NULL,
  unidade_medida VARCHAR(20)
);

-- -------- Tabela: compra_insumo --------
CREATE TABLE compra_insumo (
  id_compra INT PRIMARY KEY AUTO_INCREMENT,
  numero_nota_fiscal VARCHAR(50) UNIQUE,
  valor_total DOUBLE NOT NULL,
  quantidade_total DOUBLE NOT NULL,
  data_compra DATE NOT NULL,
  fk_id_fornecedor INT NOT NULL,
  observacoes TEXT,
  FOREIGN KEY (fk_id_fornecedor) REFERENCES Fornecedor (id_fornecedor)
);

-- -------- Tabela: item_da_compra --------
CREATE TABLE item_da_compra (
  id_item INT PRIMARY KEY AUTO_INCREMENT,
  quantidade DOUBLE NOT NULL,
  valor_unitario DOUBLE NOT NULL,
  lote VARCHAR(50),
  data_validade DATE,
  fk_id_compra INT NOT NULL,
  fk_id_insumo INT NOT NULL,
  FOREIGN KEY (fk_id_compra) REFERENCES compra_insumo (id_compra),
  FOREIGN KEY (fk_id_insumo) REFERENCES suplemento_medicamento (id_insumo)
);

-- -------- Tabela: compra_animais --------
CREATE TABLE compra_animais (
  id_compra INT PRIMARY KEY AUTO_INCREMENT,
  data_compra DATE NOT NULL,
  numero_nota_fiscal VARCHAR(50) UNIQUE,
  valor_total_nota DOUBLE NOT NULL,
  valor_frete DOUBLE,
  GTA VARCHAR(300),
  quantidade INT,
  fk_id_fornecedor INT NOT NULL,
  FOREIGN KEY (fk_id_fornecedor) REFERENCES Fornecedor (id_fornecedor)
);

-- -------- Tabela: lote_animais --------
CREATE TABLE lote_animais (
  id_lote INT PRIMARY KEY AUTO_INCREMENT,
  descricao VARCHAR(255),
  categoria_lote VARCHAR(100),
  data_criacao DATE NOT NULL,
  fk_id_funcionario INT,
  FOREIGN KEY (fk_id_funcionario) REFERENCES Funcionario (id_funcionario)
);

-- -------- Tabela: mov_lote_pasto --------
CREATE TABLE mov_lote_pasto (
  id INT PRIMARY KEY AUTO_INCREMENT,
  descricao VARCHAR(255),
  data_entrada DATE NOT NULL,
  data_saida DATETIME,
  fk_id_pasto INT NOT NULL,
  fk_id_lote INT NOT NULL,
  FOREIGN KEY (fk_id_pasto) REFERENCES Pasto (id_pasto),
  FOREIGN KEY (fk_id_lote) REFERENCES lote_animais (id_lote)
);

-- -------- Tabela: animal --------
CREATE TABLE animal (
  id_animal INT PRIMARY KEY AUTO_INCREMENT,
  numero_brinco VARCHAR(50) UNIQUE,
  finalidade_primaria VARCHAR(100),
  descricao TEXT,
  sexo VARCHAR(20) NOT NULL, -- Ex: 'MACHO', 'FÊMEA'
  status_animal VARCHAR(20) NOT NULL, -- Ex: 'ATIVO', 'VENDIDO', 'MORTO', 'DESCARTE'
  fk_id_compra INT,
  data_nascimento_estimada DATE NOT NULL,
  fk_id_raca INT NOT NULL,
  fk_id_tpAnimal INT NOT NULL,
  FOREIGN KEY (fk_id_compra) REFERENCES compra_animais (id_compra),
  FOREIGN KEY (fk_id_raca) REFERENCES Raca (id_raca),
  FOREIGN KEY (fk_id_tpAnimal) REFERENCES Tipo_animal (id_tpAnimal)
);

-- -------- Tabela: mov_animal_lote --------
CREATE TABLE mov_animal_lote (
  id INT PRIMARY KEY AUTO_INCREMENT,
  fk_id_animal INT NOT NULL,
  fk_id_lote INT NOT NULL,
  data_entrada DATE NOT NULL,
  data_saida DATE,
  FOREIGN KEY (fk_id_animal) REFERENCES animal (id_animal),
  FOREIGN KEY (fk_id_lote) REFERENCES lote_animais (id_lote)
);


-- -------- Tabela: historico_insumo (Aplicação em Lote) --------
CREATE TABLE historico_insumo_lote (
  id INT PRIMARY KEY AUTO_INCREMENT,
  data_aplicacao DATE NOT NULL,
  quantidade_usada DOUBLE NOT NULL,
  fk_id_lote INT NOT NULL,
  fk_id_insumo INT NOT NULL,
  fk_id_funcionario INT NOT NULL,
  FOREIGN KEY (fk_id_funcionario) REFERENCES funcionario(id_funcionario),
  FOREIGN KEY (fk_id_lote) REFERENCES lote_animais (id_lote),
  FOREIGN KEY (fk_id_insumo) REFERENCES suplemento_medicamento (id_insumo)
);

-- -------- Tabela: historico_insumo_animal (Aplicação Individual) --------
CREATE TABLE historico_insumo_animal (
  id INT PRIMARY KEY AUTO_INCREMENT,
  descricao VARCHAR(255),
  data_aplicacao DATE NOT NULL,
  quantidade_usada DOUBLE NOT NULL,
  fk_id_animal INT NOT NULL,
  fk_id_insumo INT NOT NULL,
  fk_id_funcionario INT NOT NULL,
  FOREIGN KEY (fk_id_funcionario) REFERENCES funcionario(id_funcionario),
  FOREIGN KEY (fk_id_animal) REFERENCES animal (id_animal),
  FOREIGN KEY (fk_id_insumo) REFERENCES suplemento_medicamento (id_insumo)
);

-- -------- Tabela: peso_animal --------
CREATE TABLE peso_animal (
  id_peso INT PRIMARY KEY AUTO_INCREMENT,
  unidade_medida VARCHAR(10) NOT NULL,
  peso DOUBLE NOT NULL,
  data_pesagem DATE NOT NULL,
  fk_id_animal INT NOT NULL,
  FOREIGN KEY (fk_id_animal) REFERENCES animal (id_animal)
);

-- -------- Tabela: venda --------
CREATE TABLE venda (
  id_venda INT PRIMARY KEY AUTO_INCREMENT,
  data_venda DATE NOT NULL,
  valor_total DOUBLE NOT NULL,
  numero_nota_fiscal VARCHAR(50) NOT NULL UNIQUE,
  GTA VARCHAR(300),
  fk_id_cliente INT NOT NULL,
  FOREIGN KEY (fk_id_cliente) REFERENCES Cliente (id_cliente)
);

-- -------- Tabela: item_venda --------
CREATE TABLE item_venda (
  id_item INT PRIMARY KEY AUTO_INCREMENT,
  valor_unitario DOUBLE NOT NULL,
  tipo_preco VARCHAR(20) NOT NULL, -- Ex: 'KG', 'ARROBA', 'CABECA'
  peso_venda DOUBLE,
  observacao_item TEXT,
  fk_id_venda INT NOT NULL,
  fk_id_animal INT NOT NULL UNIQUE,
  FOREIGN KEY (fk_id_venda) REFERENCES venda (id_venda),
  FOREIGN KEY (fk_id_animal) REFERENCES animal (id_animal)
);

-- -------- Tabela: recebimento --------
CREATE TABLE recebimento (
  id INT PRIMARY KEY AUTO_INCREMENT,
  descricao VARCHAR(255),
  valor_recebido DOUBLE NOT NULL,
  data_recebimento DATE NOT NULL,
  forma_pagamento VARCHAR(50),
  fk_id_venda INT NOT NULL,
  FOREIGN KEY (fk_id_venda) REFERENCES venda (id_venda)
);

```
