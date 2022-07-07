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
```
/profissional/busca/todos
```

> Busca profissional por nome
```
/profissional/busca/nome/{nome}
```

> Busca profissionais por range de registro
```
/profissional/busca/registro/{x-y}
```

> Busca profissionais ativos
```
/profissional/busca/ativo
```

