-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema coltec
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema coltec
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `coltec` DEFAULT CHARACTER SET utf8 ;
USE `coltec` ;

-- -----------------------------------------------------
-- Table `coltec`.`Banco`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `coltec`.`Banco` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `coltec`.`Agencia`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `coltec`.`Agencia` (
  `codigo` VARCHAR(10) NOT NULL,
  `id_banco` INT NULL,
  PRIMARY KEY (`codigo`),
  INDEX `id_banco_idx` (`id_banco` ASC) VISIBLE,
  CONSTRAINT `id_banco`
    FOREIGN KEY (`id_banco`)
    REFERENCES `coltec`.`Banco` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `coltec`.`Cliente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `coltec`.`Cliente` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `nome` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `coltec`.`Conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `coltec`.`Conta` (
  `numero` VARCHAR(10) NOT NULL,
  `codigo_agencia` VARCHAR(10) NULL,
  PRIMARY KEY (`numero`),
  INDEX `codigo_agencia_idx` (`codigo_agencia` ASC) VISIBLE,
  CONSTRAINT `codigo_agencia`
    FOREIGN KEY (`codigo_agencia`)
    REFERENCES `coltec`.`Agencia` (`codigo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `coltec`.`Cliente_Conta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `coltec`.`Cliente_Conta` (
  `id_cliente` INT NOT NULL,
  `numero_conta` VARCHAR(10) NULL,
  PRIMARY KEY (`id_cliente`),
  INDEX `numero_conta_idx` (`numero_conta` ASC) VISIBLE,
  CONSTRAINT `id_cliente`
    FOREIGN KEY (`id_cliente`)
    REFERENCES `coltec`.`Cliente` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `numero_conta`
    FOREIGN KEY (`numero_conta`)
    REFERENCES `coltec`.`Conta` (`numero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
