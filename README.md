# SIGESC - Sistema de Gestão de Escalas

![GitHub](https://img.shields.io/badge/C%23-8.0-blue)
![GitHub](https://img.shields.io/badge/.NET-8.0-red)
![GitHub](https://img.shields.io/badge/MySQL-8.0-orange)
![GitHub](https://img.shields.io/badge/Swagger-6.6.2-green)

O **SIGESC** é um sistema de gestão de escalas desenvolvido como parte dos requisitos para a aprovação na disciplina de **Programação com Acesso a Banco de Dados** do curso de **Análise e Desenvolvimento de Sistemas** no **IFRO** (5º período).

Este projeto consiste em uma **API RESTful** que permite o gerenciamento de escalas de trabalho, combatentes, usuários, turnos e muito mais. A API foi desenvolvida em **C#** com **.NET 8.0** e utiliza o **Entity Framework Core** para acesso ao banco de dados **MySQL**.

---

## 🚀 Funcionalidades

- **Autenticação e Autorização**:
  - Login de usuários com geração de token JWT.
  - Proteção de endpoints com autenticação baseada em roles (Administrador, Usuário Comum).

- **Gestão de Usuários**:
  - Cadastro, edição e exclusão de usuários.
  - Atribuição de tipos de usuários (Administrador, Usuário Comum).

- **Gestão de Escalas**:
  - Criação, atualização e exclusão de escalas de trabalho.
  - Associação de escalas a usuários.

- **Gestão de Combatentes**:
  - Cadastro de combatentes com informações detalhadas (nome, CPF, especializações, funções, restrições).
  - Atribuição de turnos de trabalho a combatentes.

- **Gestão de Turnos**:
  - Criação de turnos de trabalho com horários de início e fim.
  - Verificação automática de descanso mínimo entre turnos.

- **Swagger**:
  - Documentação interativa da API com Swagger.
  - Teste de endpoints diretamente na interface do Swagger.

---

## 🛠️ Tecnologias Utilizadas

- **Linguagem**: C# 8.0
- **Framework**: .NET 8.0
- **Banco de Dados**: MySQL
- **ORM**: Entity Framework Core (8.0.11)
- **Autenticação**: JWT (JSON Web Tokens) (8.0.13)
- **Documentação**: Swagger (Swashbuckle.AspNetCore) (6.6.2)
- 
---

## 📋 Estrutura do Projeto

O projeto está organizado da seguinte forma:

- **Controllers**:
  - `AuthController`: Gerencia autenticação e geração de tokens JWT.
  - `UsuarioController`: Gerencia operações relacionadas a usuários.
  - `EscalaController`: Gerencia operações relacionadas a escalas.
  - `TurnoTrabalhoController`: Gerencia operações relacionadas a turnos de trabalho.
  - `CombatenteController`: Gerencia operações relacionadas a combatentes.

- **Models**:
  - `Usuario`: Representa um usuário do sistema.
  - `Escala`: Representa uma escala de trabalho.
  - `TurnoTrabalho`: Representa um turno de trabalho.
  - `Combatente`: Representa um combatente.

- **DTOs**:
  - `LoginDto`: DTO para autenticação de usuários.
  - `UsuarioDto`: DTO para operações de usuários.
  - `EscalaDto`: DTO para operações de escalas.
  - `TurnoTrabalhoDto`: DTO para operações de turnos de trabalho.

- **Database**:
  - Script SQL para criação do banco de dados e tabelas.

---
