--Create a new sample databse and grant all privilgies
SELECT 'CREATE DATABASE sistemavotacao'
WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'sistemavotacao')\gexec
grant all privileges on database sistemavotacao to postgres;

CREATE TABLE funcionarios (
  id SERIAL PRIMARY KEY,
  nome VARCHAR(255),
  email TEXT UNIQUE NOT NULL,
  senha TEXT
);

CREATE TABLE recursos (
  id SERIAL PRIMARY KEY,
  nome VARCHAR(255)
);

CREATE TABLE votos (
  id SERIAL PRIMARY KEY,
  data_criacao VARCHAR(50),
  id_recurso INT NOT NULL,
  id_funcionario INT NOT NULL,

  CONSTRAINT fk_recurso
      FOREIGN KEY(id_recurso) 
	  REFERENCES recursos(id),

  CONSTRAINT fk_funcionario
      FOREIGN KEY(id_funcionario) 
	  REFERENCES funcionarios(id) 
 
);




  
  -- id_recurso INT FOREIGN KEY REFERENCES recurso(id),
  -- id_usuario INT FOREIGN KEY REFERENCES funcionarios(id),




