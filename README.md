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


```
USE fazenda;

-- -------- Bloco 1: Inserção em Tabelas Independentes (Dados Mestres) --------
-- Estas tabelas não possuem chaves estrangeiras e devem ser populadas primeiro.

-- -------- Tabela: Raca --------
INSERT INTO Raca(nome_raca, descricao_raca, codigo_raca) VALUES
('Nelore', 'Raça zebuína de grande porte, originária da Índia.', 'NEL'),
('Angus', 'Raça taurina de origem escocesa, conhecida pela qualidade da carne.', 'ANG'),
('Brahman', 'Raça zebuína desenvolvida nos Estados Unidos, resistente ao calor.', 'BRA'),
('Senepol', 'Raça taurina adaptada aos trópicos, sem chifres.', 'SEN'),
('Guzerá', 'Raça zebuína de dupla aptidão (carne e leite).', 'GUZ'),
('Tabapuã', 'Raça zebuína brasileira, mocho e de excelente habilidade materna.', 'TAB'),
('Hereford', 'Raça britânica, rústica e com boa conversão alimentar.', 'HER'),
('Brangus', 'Cruzamento entre Brahman e Angus.', 'BGS'),
('Girolando', 'Cruzamento entre Gir e Holandês, voltado para leite.', 'GIR'),
('Holandês', 'Raça leiteira de alta produção, de origem holandesa.', 'HOL');

-- -------- Tabela: Tipo_animal --------
INSERT INTO Tipo_animal(nome, idade_minima_meses, idade_maxima_meses) VALUES
('Bezerro', 0, 12),
('Bezerra', 0, 12),
('Garrote', 13, 24),
('Novilha', 13, 24),
('Boi Magro', 25, 36),
('Boi Gordo', 25, 48),
('Vaca', 25, 120),
('Touro', 24, 120),
('Vaca de Descarte', 121, 240),
('Bezerras de Leilão', 6, 10);

-- -------- Tabela: Cliente --------
INSERT INTO Cliente(nome, cpf_cnpj, data_cadastro, telefone, email, endereco, cidade, estado, incricao_estatual, tipo_cliente, status_cliente) VALUES
('João da Silva', '111.222.333-44', '2022-01-15', '(11) 98765-4321', 'joao.silva@email.com', 'Rua das Flores, 123', 'São Paulo', 'SP', 'ISENTO', 'FÍSICA', 'ATIVO'),
('Frigorífico Boi Bom Ltda', '12.345.678/0001-99', '2022-02-20', '(62) 3232-4545', 'compras@boibom.com', 'Av. Industrial, 500', 'Goiânia', 'GO', '10.123.456-7', 'JURÍDICA', 'ATIVO'),
('Maria Oliveira', '222.333.444-55', '2022-03-10', '(21) 99887-6655', 'maria.o@email.com', 'Rua da Praia, 456', 'Rio de Janeiro', 'RJ', 'ISENTO', 'FÍSICA', 'ATIVO'),
('Agropecuária Pasto Verde S.A.', '23.456.789/0001-00', '2022-04-05', '(67) 3434-5656', 'contato@pastoverde.com', 'Rodovia BR-163, Km 10', 'Campo Grande', 'MS', '28.987.654-3', 'JURÍDICA', 'ATIVO'),
('Pedro Souza', '333.444.555-66', '2022-05-12', '(31) 98888-7777', 'pedro.souza@email.com', 'Av. Afonso Pena, 789', 'Belo Horizonte', 'MG', 'ISENTO', 'FÍSICA', 'INATIVO'),
('Cooperativa de Produtores Rurais', '34.567.890/0001-11', '2022-06-18', '(41) 3333-8888', 'cooperativa@email.com', 'Rua das Araucárias, 1010', 'Curitiba', 'PR', '90.543.210-9', 'JURÍDICA', 'ATIVO'),
('Ana Costa', '444.555.666-77', '2022-07-22', '(71) 97777-6666', 'ana.costa@email.com', 'Ladeira do Pelourinho, 11', 'Salvador', 'BA', 'ISENTO', 'FÍSICA', 'ATIVO'),
('Leilões de Gado Rurais Ltda', '45.678.901/0001-22', '2022-08-30', '(51) 3456-7890', 'leiloes@email.com', 'Av. Ipiranga, 1212', 'Porto Alegre', 'RS', '245.876.123-0', 'JURÍDICA', 'ATIVO');

-- -------- Tabela: Funcionario --------
INSERT INTO Funcionario(nome_fun, cpf, data_nascimento, sexo, endereco, cidade, estado, telefone, email, data_admissao, cargo, salario, status_funcionario, tipo_contrato) VALUES
('José Aparecido', '123.456.789-01', '1980-05-10', 'MASCULINO', 'Rua do Sindicato, 10', 'Uberaba', 'MG', '(34) 99991-1111', 'jose.a@email.com', '2010-03-01', 'Gerente da Fazenda', 7500.00, 'ATIVO', 'CLT'),
('Antônio Carlos', '234.567.890-12', '1990-08-20', 'MASCULINO', 'Vila Rural, Casa 2', 'Campo Grande', 'MS', '(67) 99992-2222', 'antonio.c@email.com', '2015-07-15', 'Vaqueiro', 2800.00, 'ATIVO', 'CLT'),
('Mariana Silva', '345.678.901-23', '1995-02-25', 'FEMININO', 'Av. Principal, 202', 'Goiânia', 'GO', '(62) 99993-3333', 'mariana.s@email.com', '2018-01-10', 'Veterinária', 8500.00, 'ATIVO', 'PJ'),
('Cláudio Ribeiro', '456.789.012-34', '1988-11-30', 'MASCULINO', 'Rua da Estação, 303', 'Barreiras', 'BA', '(77) 99994-4444', 'claudio.r@email.com', '2019-05-20', 'Tratorista', 3200.00, 'ATIVO', 'CLT'),
('Fernanda Lima', '567.890.123-45', '2000-01-01', 'FEMININO', 'Centro, Sala 5', 'São Paulo', 'SP', '(11) 99995-5555', 'fernanda.l@email.com', '2021-02-01', 'Administrativo', 4000.00, 'ATIVO', 'CLT'),
('Ricardo Almeida', '678.901.234-56', '1975-06-15', 'MASCULINO', 'Sítio Boa Esperança', 'Uberaba', 'MG', '(34) 99996-6666', 'ricardo.a@email.com', '2012-09-01', 'Capataz', 4500.00, 'ATIVO', 'CLT'),
('Patrícia Mello', '789.012.345-67', '1998-09-08', 'FEMININO', 'Alameda dos Ypês, 404', 'Ribeirão Preto', 'SP', '(16) 99997-7777', 'patricia.m@email.com', '2022-03-15', 'Zootecnista', 6800.00, 'ATIVO', 'PJ'),
('Luiz Gonzaga', '890.123.456-78', '1992-04-12', 'MASCULINO', 'Fazenda vizinha, s/n', 'Corumbá', 'MS', '(67) 99998-8888', 'luiz.g@email.com', '2020-11-20', 'Vaqueiro', 2800.00, 'ATIVO', 'CLT'),
('Júlia Santos', '901.234.567-89', '2001-07-19', 'FEMININO', 'Rua B, 505', 'Goiânia', 'GO', '(62) 99999-9999', 'julia.s@email.com', '2023-01-20', 'Estagiária Veterinária', 1500.00, 'ATIVO', 'Estágio'),
('Marcos Rocha', '012.345.678-90', '1985-03-22', 'MASCULINO', 'Rua dos Peões, 606', 'Araçatuba', 'SP', '(18) 99990-0000', 'marcos.r@email.com', '2014-08-18', 'Tratorista', 3200.00, 'DESLIGADO', 'CLT');

-- -------- Tabela: Pasto --------
INSERT INTO Pasto(descricao, localizacao, tamanho, unidade_medida, tipo_pastagem) VALUES
('Pasto da Sede', 'Próximo à casa principal', 50, 'hectare', 'Brachiaria'),
('Pasto do Córrego', 'Margeando o Córrego Fundo', 75, 'hectare', 'Mombacks'),
('Piquete da Maternidade', 'Ao lado do curral de manejo', 10, 'hectare', 'Tifton'),
('Pasto do Retiro', 'Área mais afastada da sede', 120, 'hectare', 'Brachiaria'),
('Pasto da Várzea', 'Área baixa e úmida', 30, 'hectare', 'Humidicola'),
('Pasto do Morro Alto', 'Elevação a leste da fazenda', 85, 'hectare', 'Andropogon'),
('Alqueirão', 'Área de 10 alqueires paulista', 24.2, 'alqueire', 'Brachiaria'),
('Piquete de Quarentena', 'Isolado, próximo à entrada', 5, 'hectare', 'Mombaça'),
('Pasto de Engorda Final', 'Próximo ao confinamento', 40, 'hectare', 'Tanzânia'),
('Campo Nativo', 'Área de preservação com pastagem natural', 200, 'hectare', 'Nativo');

-- -------- Tabela: Fornecedor --------
INSERT INTO Fornecedor(razao_social, cpf_cnpj, telefone, email, endereco, cidade, estado) VALUES
('Casa do Campo Agroveterinária', '60.111.222/0001-10', '(34) 3312-1111', 'vendas@casacampo.com', 'Av. Santos Dumont, 1000', 'Uberaba', 'MG'),
('Nutrição Animal Forte S.A.', '61.222.333/0001-20', '(19) 3404-2222', 'comercial@nutricaoforte.com', 'Rod. Anhanguera, Km 150', 'Limeira', 'SP'),
('Genética Top Bull', '62.333.444/0001-30', '(62) 3505-3333', 'contato@topbull.com', 'Av. Castelo Branco, 2000', 'Goiânia', 'GO'),
('Saúde Bovina Medicamentos', '63.444.555/0001-40', '(67) 3382-4444', 'pedidos@saudebovina.com', 'Rua 14 de Julho, 3000', 'Campo Grande', 'MS'),
('Tratores & Implementos Matsuda', '64.555.666/0001-50', '(11) 4582-5555', 'vendas.sp@matsuda.com', 'Av. Jundiaí, 4000', 'Jundiaí', 'SP'),
('Sal Mineral Campestre', '65.666.777/0001-60', '(77) 3611-6666', 'sal@campestre.com', 'Distrito Industrial, Lote 5', 'Luís Eduardo Magalhães', 'BA'),
('Vacinas e Cia', '66.777.888/0001-70', '(43) 3372-7777', 'vacinascia@email.com', 'Av. Tiradentes, 5000', 'Londrina', 'PR'),
('Fazenda de Cria Progresso', '67.888.999/0001-80', '(18) 3652-8888', 'fazprogresso@email.com', 'Estrada Vicinal, Km 25', 'Andradina', 'SP'),
('Arame Farpado Pantanal', '68.999.000/0001-90', '(65) 3624-9999', 'arame@pantanal.com', 'Av. da Prainha, 6000', 'Cuiabá', 'MT'),
('Logística Rural Express', '69.000.111/0001-00', '(62) 3271-0000', 'log@ruralexpress.com', 'Polo Empresarial, 7000', 'Aparecida de Goiânia', 'GO');

-- -------- Tabela: suplemento_medicamento --------
INSERT INTO suplemento_medicamento(nome, descricao, categoria, unidade_medida) VALUES
('Vacina Aftosa', 'Vacina contra febre aftosa', 'Vacina', 'Dose'),
('Sal Mineral 80 Fósforo', 'Suplemento mineral com alta concentração de fósforo', 'Mineral', 'KG'),
('Ivermectina 1%', 'Endectocida para controle de parasitas internos e externos', 'Vermífugo', 'ML'),
('Antibiótico Terramicina LA', 'Antibiótico de longa ação à base de oxitetraciclina', 'Antibiótico', 'ML'),
('Ração de Confinamento 18% PB', 'Ração concentrada com 18% de Proteína Bruta', 'Ração', 'KG'),
('Sal Proteinado de Seca', 'Suplemento para período de seca, com ureia', 'Proteinado', 'KG'),
('Soro Antitetânico', 'Soro para prevenção e tratamento de tétano', 'Soro', 'Frasco'),
('Mosquicida Pour-On', 'Produto para controle da mosca-do-chifre', 'Mosquicida', 'ML'),
('Kit de Inseminação Artificial', 'Kit completo com luvas, bainhas e aplicador', 'Material', 'Unidade'),
('Brinco Identificador (Amarelo)', 'Brinco de plástico para identificação visual', 'Identificação', 'Unidade');


-- -------- Bloco 2: Processos de Compra (Dependem do Bloco 1) --------
-- Inserção de compras de insumos e animais, que dependem de Fornecedores e Insumos.

-- -------- Tabela: compra_insumo --------
INSERT INTO compra_insumo(numero_nota_fiscal, valor_total, quantidade_total, data_compra, fk_id_fornecedor, observacoes) VALUES
('NF-00101', 2500.50, 50, '2023-01-20', 1, 'Compra de vacinas e vermífugos'),
('NF-00102', 8500.00, 1000, '2023-01-25', 2, 'Compra de sal mineral para o lote de recria'),
('NF-00103', 1200.00, 2, '2023-02-10', 4, 'Compra de antibióticos e soro'),
('NF-00104', 15000.75, 5000, '2023-02-15', 5, 'Ração para o início do confinamento'),
('NF-00105', 450.00, 200, '2023-03-01', 10, 'Compra de brincos para nova bezerrada'),
('NF-00106', 980.00, 100, '2023-03-05', 8, 'Mosquicida para o período das chuvas'),
('NF-00107', 12300.00, 1500, '2023-04-10', 6, 'Sal proteinado para o período de seca'),
('NF-00108', 3200.00, 10, '2023-05-11', 9, 'Compra de rolos de arame farpado para reforma de cerca'),
('NF-00109', 550.00, 5, '2023-05-22', 3, 'Kit de inseminação'),
('NF-00110', 2800.00, 60, '2023-06-01', 1, 'Reposição de estoque de vacinas diversas');

-- -------- Tabela: item_da_compra --------
INSERT INTO item_da_compra(quantidade, valor_unitario, lote, data_validade, fk_id_compra, fk_id_insumo) VALUES
(50, 50.01, 'AFT2301A', '2024-01-20', 1, 1),
(1000, 8.50, 'MIN2301B', '2025-01-25', 2, 2),
(2, 600.00, 'MED2302C', '2024-08-10', 3, 4),
(5000, 3.00, 'RAC2302D', '2023-08-15', 4, 5),
(200, 2.25, 'BRI2303E', '2030-01-01', 5, 10),
(100, 9.80, 'MOS2303F', '2025-03-05', 6, 8),
(1500, 8.20, 'PRO2304G', '2024-04-10', 7, 6),
(10, 320.00, 'ARA2305H', NULL, 8, 9), -- Arame não tem validade
(5, 110.00, 'IAS2305I', '2025-05-22', 9, 9),
(60, 46.67, 'VAC2306J', '2024-06-01', 10, 1);

-- -------- Tabela: compra_animais --------
INSERT INTO compra_animais(data_compra, numero_nota_fiscal, valor_total_nota, valor_frete, GTA, quantidade, fk_id_fornecedor) VALUES
('2023-03-15', 'NFA-201', 3000.00, 500.00, 'GTA-SP-00123/23', 1, 8),
('2023-03-16', 'NFA-202', 2800.00, 500.00, 'GTA-SP-00124/23', 1, 8),
('2023-04-20', 'NFA-203', 4200.00, 600.00, 'GTA-MS-00456/23', 1, 8),
('2023-04-21', 'NFA-204', 4500.00, 600.00, 'GTA-MS-00457/23', 1, 8),
('2023-05-10', 'NFA-205', 25000.00, 500.00, 'GTA-GO-00789/23', 1, 3),
('2023-05-25', NULL, 3800.00, 700.00, 'GTA-MG-00112/23', 1, 8),
('2023-05-26', 'NFA-207', 4000.00, 700.00, 'GTA-MG-00113/23', 1, 8),
('2023-06-18', 'NFA-208', 3500.00, 400.00, 'GTA-SP-00556/23', 1, 8),
('2023-07-01', 'NFA-209', 30000.00, 600.00, 'GTA-GO-00998/23', 1, 3),
('2023-07-22', 'NFA-210', 5000.00, 800.00, 'GTA-MS-00776/23', 1, 8);


-- -------- Bloco 3: Cadastro e Organização de Animais e Lotes --------
-- Animais são cadastrados e depois alocados em lotes.

-- -------- Tabela: animal --------
-- Inserindo 10 animais como exemplo, associados a algumas das compras acima.
INSERT INTO animal(numero_brinco, finalidade_primaria, descricao, sexo, status_animal, fk_id_compra, data_nascimento_estimada, fk_id_raca, fk_id_tpAnimal) VALUES
('BR001', 'Corte', 'Bezerro Brangus', 'MACHO', 'ATIVO', 1, '2022-09-15', 8, 1),
('BR002', 'Corte', 'Bezerro Brangus', 'MACHO', 'ATIVO', 2, '2022-09-20', 8, 1),
('BR003', 'Reprodução', 'Novilha Nelore', 'FÊMEA', 'ATIVO', 3, '2021-10-20', 1, 4),
('BR004', 'Reprodução', 'Novilha Nelore', 'FÊMEA', 'ATIVO', 4, '2021-10-22', 1, 4),
('BR005', 'Reprodutor', 'Touro Guzerá P.O.', 'MACHO', 'ATIVO', 5, '2021-02-10', 5, 8),
('BR006', 'Corte', 'Garrote Senepol', 'MACHO', 'ATIVO', 6, '2021-11-25', 4, 3),
('BR007', 'Corte', 'Garrote Senepol', 'MACHO', 'ATIVO', 7, '2021-11-28', 4, 3),
('BR008', 'Corte', 'Vaca de descarte Girolando', 'FÊMEA', 'ATIVO', 8, '2015-01-01', 9, 9),
('BR009', 'Reprodutor', 'Touro Senepol P.O.', 'MACHO', 'ATIVO', 9, '2021-04-01', 4, 8),
('BR010', 'Corte', 'Boi gordo Angus', 'MACHO', 'ATIVO', 10, '2021-08-22', 2, 6);

-- -------- Tabela: lote_animais --------
INSERT INTO lote_animais(descricao, categoria_lote, data_criacao, fk_id_funcionario) VALUES
('Lote de Bezerros da Compra de Março', 'Recria', '2023-03-16', 2),
('Lote de Novilhas para Inseminação', 'Reprodução', '2023-04-21', 3),
('Touro Reprodutor P.O.', 'Reprodutor', '2023-05-10', 1),
('Lote de Garrotes para Engorda', 'Engorda', '2023-05-26', 6),
('Lote Maternidade', 'Cria', '2023-06-13', 7),
('Lote de Descarte', 'Venda', '2023-06-19', 2),
('Touro Reprodutor II', 'Reprodutor', '2023-07-02', 1),
('Lote Confinamento 01', 'Terminação', '2023-07-23', 6),
('Lote de Recria 2', 'Recria', '2023-08-06', 2),
('Lote de Fêmeas para Leilão', 'Venda', '2023-08-31', 1);


-- -------- Bloco 4: Movimentações e Históricos (Dependem dos Blocos 1, 2 e 3) --------
-- Registros de movimentação, pesagem e aplicação de insumos.

-- -------- Tabela: mov_animal_lote --------
INSERT INTO mov_animal_lote(fk_id_animal, fk_id_lote, data_entrada, data_saida) VALUES
(1, 1, '2023-03-16', NULL),
(2, 1, '2023-03-16', NULL),
(3, 2, '2023-04-21', NULL),
(4, 2, '2023-04-21', NULL),
(5, 3, '2023-05-10', NULL),
(6, 4, '2023-05-26', NULL),
(7, 4, '2023-05-26', NULL),
(8, 6, '2023-06-19', '2023-07-19'),
(9, 7, '2023-07-02', NULL),
(10, 8, '2023-07-23', NULL);

-- -------- Tabela: mov_lote_pasto --------
INSERT INTO mov_lote_pasto(descricao, data_entrada, data_saida, fk_id_pasto, fk_id_lote) VALUES
('Alocação inicial Lote de Bezerros', '2023-03-16', '2023-06-30', 1, 1),
('Alocação inicial Lote de Novilhas', '2023-04-21', '2023-08-01', 2, 2),
('Alocação Touro na maternidade', '2023-05-10', NULL, 3, 3),
('Alocação Lote Engorda no pasto do Retiro', '2023-05-26', NULL, 4, 4),
('Lote de Descarte no pasto do Córrego', '2023-06-19', '2023-07-19', 2, 6),
('Alocação Touro II', '2023-07-02', NULL, 3, 7),
('Lote de Confinamento no pasto pré-confinamento', '2023-07-23', '2023-08-23', 9, 8),
('Alocação Recria 2', '2023-08-06', NULL, 5, 9),
('Lote de Fêmeas para leilão no Piquete', '2023-08-31', NULL, 8, 10),
('Rodízio de pasto do Lote de Bezerros', '2023-07-01', NULL, 6, 1);

-- -------- Tabela: historico_insumo_lote (Aplicação em Lote) --------

INSERT INTO historico_insumo_lote(data_aplicacao, quantidade_usada, fk_id_lote, fk_id_insumo, fk_id_funcionario) VALUES
('2023-03-17', 50, 1, 1, 2),  -- Vaqueiro Antônio aplicou
('2023-04-22', 250, 2, 2, 7), -- Zootecnista Patrícia aplicou
('2023-05-27', 40, 4, 3, 2),  -- Vaqueiro Antônio aplicou
('2023-06-20', 200, 6, 6, 8), -- Vaqueiro Luiz aplicou
('2023-07-24', 500, 8, 5, 6),  -- Capataz Ricardo aplicou
('2023-08-07', 300, 9, 2, 2),  -- Vaqueiro Antônio aplicou
('2023-09-01', 30, 10, 1, 3), -- Veterinária Mariana aplicou
('2023-04-01', 10, 1, 3, 2),  -- Vaqueiro Antônio aplicou
('2023-05-01', 10, 2, 3, 3),  -- Veterinária Mariana aplicou
('2023-06-01', 10, 4, 3, 8);  -- Vaqueiro Luiz aplicou

-- -------- Tabela: historico_insumo_animal (Aplicação Individual) --------

INSERT INTO historico_insumo_animal(descricao, data_aplicacao, quantidade_usada, fk_id_animal, fk_id_insumo, fk_id_funcionario) VALUES
('Tratamento de pneumonia no bezerro BR001', '2023-04-05', 20, 1, 4, 3), -- Veterinária
('Tratamento de ferida no touro BR005', '2023-06-10', 15, 5, 4, 3),      -- Veterinária
('Aplicação de soro por picada de cobra', '2023-07-15', 1, 3, 7, 2),       -- Vaqueiro
('Reforço de vermífugo no animal BR006', '2023-08-01', 10, 6, 3, 2),      -- Vaqueiro
('Tratamento de infecção ocular no BR002', '2023-04-12', 10, 2, 4, 9),    -- Estagiária
('Aplicação de vermífugo preventivo', '2023-09-02', 10, 7, 3, 8),        -- Vaqueiro
('Tratamento de casco', '2023-09-15', 8, 9, 4, 3),                        -- Veterinária
('Aplicação de vermífugo no animal BR010', '2023-09-20', 10, 10, 3, 6);   -- Capataz

-- -------- Tabela: peso_animal --------
INSERT INTO peso_animal(unidade_medida, peso, data_pesagem, fk_id_animal) VALUES
('KG', 180.5, '2023-03-16', 1),
('KG', 182.0, '2023-03-16', 2),
('KG', 380.0, '2023-04-21', 3),
('KG', 385.5, '2023-04-21', 4),
('KG', 950.0, '2023-05-10', 5),
('KG', 450.0, '2023-09-01', 1),
('KG', 455.0, '2023-09-01', 2),
('KG', 420.0, '2023-09-01', 3),
('KG', 430.0, '2023-09-01', 4),
('KG', 1000.0, '2023-09-01', 5);


-- -------- Bloco 5: Processo de Venda e Recebimento (Fim do Ciclo) --------

-- -------- Tabela: venda --------
INSERT INTO venda(data_venda, valor_total, numero_nota_fiscal, GTA, fk_id_cliente) VALUES
('2023-07-20', 12500.00, 'NFS-501', 'GTA-OUT-001/23', 1),  -- Total = 12500.00
('2023-08-15', 10000.00, 'NFS-502', 'GTA-OUT-002/23', 2),  -- Total = 5000 + 5000 = 10000.00
('2023-08-20', 9800.00,  'NFS-503', 'GTA-OUT-003/23', 3),  -- Total = 9800.00
('2023-09-01', 9600.00,  'NFS-504', 'GTA-OUT-004/23', 4),  -- Total = 4800 + 4800 = 9600.00
('2023-09-05', 15000.00, 'NFS-505', 'GTA-OUT-005/23', 5),  -- Total = 15000.00
('2023-09-10', 25000.00, 'NFS-506', 'GTA-OUT-006/23', 6),  -- Total = 25000.00
('2023-09-15', 8500.00,  'NFS-507', 'GTA-OUT-007/23', 7),  -- Total = 8500.00
('2023-09-20', 30000.00, 'NFS-508', 'GTA-OUT-008/23', 8);  -- Total = 30000.00

-- -------- Tabela: item_venda --------
INSERT INTO item_venda(valor_unitario, tipo_preco, peso_venda, observacao_item, fk_id_venda, fk_id_animal) VALUES
(12500.00, 'CABECA', 450, 'Venda do animal BR008', 1, 8), -- Venda 1
(5000.00, 'CABECA', 480, 'Item 1 da Venda para Frigorífico', 2, 1), -- Venda 2
(5000.00, 'CABECA', 485, 'Item 2 da Venda para Frigorífico', 2, 2), -- Venda 2
(9800.00, 'CABECA', 430, 'Venda da novilha BR003', 3, 3), -- Venda 3
(4800.00, 'CABECA', 500, 'Item 1 da Venda para Agropecuária', 4, 6), -- Venda 4
(4800.00, 'CABECA', 510, 'Item 2 da Venda para Agropecuária', 4, 7), -- Venda 4
(15000.00, 'CABECA', 440, 'Venda da novilha BR004', 5, 4), -- Venda 5
(25000.00, 'CABECA', 1000, 'Venda do Touro BR005', 6, 5), -- Venda 6
(8500.00, 'CABECA', 450, 'Venda de animal avulso', 7, 10), -- Venda 7
(30000.00, 'CABECA', 1050, 'Venda do Touro BR009', 8, 9); -- Venda 8

-- -------- Tabela: recebimento --------
INSERT INTO recebimento(descricao, valor_recebido, data_recebimento, forma_pagamento, fk_id_venda) VALUES
('Pagamento à vista da venda NFS-501', 12500.00, '2023-07-20', 'PIX', 1),
('Primeira parcela da venda NFS-502', 5000.00, '2023-08-15', 'BOLETO', 2),
('Segunda parcela da venda NFS-502', 5000.00, '2023-09-15', 'BOLETO', 2),
('Pagamento da venda NFS-503', 9800.00, '2023-08-21', 'DINHEIRO', 3),
('Entrada da venda NFS-504', 9600.00, '2023-09-01', 'TED', 4),
('Pagamento total venda NFS-505', 15000.00, '2023-09-05', 'PIX', 5),
('Pagamento venda NFS-507', 8500.00, '2023-09-15', 'PIX', 7),
('Pagamento da entrada da venda NFS-506', 25000.00, '2023-09-10', 'BOLETO', 6);
```
