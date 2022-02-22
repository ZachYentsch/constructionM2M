CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS contractors(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  specialty VARCHAR(255) NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS companies(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name VARCHAR(255) NOT NULL,
  location VARCHAR(255) NOT NULL
) default charset utf8 COMMENT '';
CREATE TABLE IF NOT EXISTS jobs(
  id INT NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
  contractorId INT NOT NULL,
  companyId INT NOT NULL,
  FOREIGN KEY(contractorId) REFERENCES contractors(id),
  FOREIGN KEY(companyId) REFERENCES companies(id)
) default charset utf8 COMMENT '';
DROP Table contractors;
DROP Table companies;
DROP Table jobs;
INSERT INTO
  companies (name, location)
VALUES("HighCascade", "Mt Hood");
INSERT INTO
  contractors (name, specialty)
VALUES("TimToms", "Excavating");
INSERT INTO
  jobs (companyId, contractorId)
VALUES(1, 2);
SELECT
  *
From
  companies;
SELECT
  *
FROM
  contractors;
SELECT
  cons.*,
  coms.location,
  j.id AS JobId,
  j.companyId,
  j.contractorId
FROM
  jobs j
  JOIN companies coms ON coms.id = j.companyId
  JOIN contractors cons ON cons.id = j.contractorId
WHERE
  j.id = 1;