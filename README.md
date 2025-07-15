# Banco de dados.

CREATE DATABASE Fazenda;
USE fazenda;
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


Inserção de Dados para fornecedor
INSERT INTO Fornecedor(razao_social, cpf_cnpj, telefone, email, endereco, cidade, estado) VALUES
('Fazenda Iracema', '60.111.222/0001-10', '(34) 3312-1111', 'fazendairacema@gmail.com', 'Av. Santos Dumont, 1000', 'Uberaba', 'MG'),
('Fazenda da Cachoeira', '61.222.333/0001-20', '(19) 3404-2222', 'fazendadacachoeira@gmail.com', 'Rod. Anhanguera, Km 150', 'Limeira', 'SP'),
('Genética Top Bull', '62.333.444/0001-30', '(62) 3505-3333', 'geneticatopbull@gmail.com', 'Av. Castelo Branco, 2000', 'Goiânia', 'GO'),
('Fazenda Boi Bom', '63.444.555/0001-40', '(67) 3382-4444', 'boibom@gmail.com', 'Rua 14 de Julho, 3000', 'Campo Grande', 'MS'),
('Fazenda 3 Irmão', '64.555.666/0001-50', '(11) 4582-5555', 'fazenda3irmao@gmail.com', 'Av. Jundiaí, 4000', 'Jundiaí', 'SP'),
('Fazenda dos Ypês', '65.666.777/0001-60', '(77) 3611-6666', 'fazendadosypes@gmail.com', 'Distrito Industrial, Lote 5', 'Luís Eduardo Magalhães', 'BA'),
('Fazenda 3 Marias', '66.777.888/0001-70', '(43) 3372-7777', 'fazenda3marias@gmail.com', 'Av. Tiradentes, 5000', 'Londrina', 'PR'),
('Fazenda de Cria Progresso', '67.888.999/0001-80', '(18) 3652-8888', 'fazendaprogressocria@gmail.com', 'Estrada Vicinal, Km 25', 'Andradina', 'SP'),
('Fazenda Marte', '68.999.000/0001-90', '(65) 3624-9999', 'fazendamarte@gmail.com', 'Av. da Prainha, 6000', 'Cuiabá', 'MT'),
('Fazenda Lagoa Verde', '69.000.111/0001-00', '(62) 3271-0000', 'fazendalagoaverde@gmail.com', 'Polo Empresarial, 7000', 'Aparecida de Goiânia', 'GO');
