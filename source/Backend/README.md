# 🚀 Instruções para Execução

---

## ✅ 1. Verificações Iniciais

Verificar se a ferramenta ef está instalada, executar o comando:

```bash
dotnet ef
```

Se já estiver instalada verificar a versão, pois precisa estar na versão 8.0.27 com o comando:

```bash
dotnet ef --version
```

Caso precise instalar, utilizar o comando:

```bash
dotnet tools install --global ef --version 8.0.27
```

---

Caso precise atualizar para a versão, execute o comando:

```bash
dotnet tool update --global dotnet-ef --version 8.0.27
```

---

## 📦 2. Restaurar os Pacotes

```bash
dotnet restore
```

---

## 🔄 3. Executar as Migrações

```bash
dotnet ef migrations add Initial
```

---

## 🗄️ 4. Criar o Banco e Tabela

```bash
dotnet ef database update
```

---

## 🎨 5. Executar o Front-end para configurar o CORS

Obter a URL do front-end e substituir a string `URL_FRONT_END` no arquivo `appsettings.json`

---

## ▶️ 6. Executar a Aplicação

```bash
dotnet run
```

---
