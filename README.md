# Implanta – Desafio 1
CRUD de Profissional com m ASP.NET API
- C#
- Arquitetura MVC
- Entity Framework
- SQL Serve

Atributos de Profissional


```
Id int
NomeCompleto string
CPF string
DataNascimento Datetime 
Sexo string 
Apenas 1 caractere (M = Masculino,F = Feminino )
Ativo boolean
NumeroRegistro int 
CEP string 
Cidade string 
ValorRenda decimal 
DataCriacao Datetime 
```

## ENDPOINT
> Buscar todos os profissionais em ordem alfabetica
{GET}
```
/profissional/busca/todos
```

> Busca profissional por nome
{GET}
```
/profissional/busca/nome/{nome}
```

> Busca profissionais por range de registro
{GET}
```
/profissional/busca/registro/{x-y}
```

> Busca profissionais ativos
{GET}
```
/profissional/busca/ativo
```

> Criar profissional
{POST}
```
/profissional
```
Passar profissional no corpo da requisição. Profissional (NomeCompleto,CPF, DataNascimento, Sexo, Ativo, NumeroRegistro, CEP, Cidade, ValorRenda)

> Editar profissional
{PUT}
```
/profissional/{id}
```
Passar profissional no corpo da requisição. Profissional (NomeCompleto,CPF, DataNascimento, Sexo, Ativo, CEP, Cidade, ValorRenda)

> Deletar profissional
{DELETE}
```
/profissional/{id}
```
