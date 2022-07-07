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
Apenas 1 caractere (M = Masculino, F = Feminino )
Ativo boolean
NumeroRegistro int 
CEP string 
Cidade string 
ValorRenda decimal 
DataCriacao Datetime 
```

## ENDPOINT
> Buscar todos os profissionais em ordem alfabética
{GET}
Resposta: lista de profissionais
```
/profissional/busca/todos
```

> Busca profissional por nome
{GET}
Resposta: lista de profissionais
```
/profissional/busca/nome/{nome}
```

> Busca profissionais por range de registro
{GET}
Resposta: lista de profissionais
```
/profissional/busca/registro/{x-y}
```

> Busca profissionais ativos
{GET}
Resposta: lista de profissionais
```
/profissional/busca/ativo
```

> Criar profissional
{POST}
Resposta: profissional criado
```
/profissional
```
Passar profissional no corpo da requisição. Profissional (NomeCompleto,CPF, DataNascimento, Sexo, Ativo, NumeroRegistro, CEP, Cidade, ValorRenda)

> Editar profissional
{PUT}
Resposta: profissional editado
```
/profissional/{id}
```
Passar profissional no corpo da requisição. Profissional (NomeCompleto,CPF, DataNascimento, Sexo, Ativo, CEP, Cidade, ValorRenda)

> Deletar profissional
{DELETE}
Resposta: profissional deletado
```
/profissional/{id}
```
