# ⏱️ Stopwatch Console App (C#)

Aplicação de cronômetro em **C# (.NET)** executada no **console**, com suporte a contagem crescente ou decrescente, pausa, retomada e reinício.

Projeto criado com foco em **lógica**, **controle de estado** e **boas práticas para nível Júnior**.

---

## 🚀 Funcionalidades

- ⬆️ Contagem **crescente**
- ⬇️ Contagem **decrescente**
- ⏸️ **Pause**
- ▶️ **Resume**
- 🔄 **Restart**
- ❌ **Exit**
- ⏱️ Suporte a **segundos (s)** e **minutos (m)**
- ✅ Validação de entrada do usuário
- ❌ Sem loops infinitos

---

## 🧠 Regras de Funcionamento

- O usuário deve informar o tempo no formato:
  - `10s` → 10 segundos
  - `2m` → 2 minutos
- O sufixo `s` ou `m` é **obrigatório**
- Em modo **Crescente**, o cronômetro começa no **menor valor**
- Em modo **Decrescente**, começa no **maior valor**

---

## 🎮 Controles Durante a Execução

| Tecla | Ação      |
| ----- | --------- |
| `P`   | Pausar    |
| `R`   | Retomar   |
| `S`   | Reiniciar |
| `E`   | Encerrar  |

---

## 🛠️ Tecnologias Utilizadas

- C#
- .NET Console Application
- Programação Orientada a Objetos
- Threading (`Thread.Sleep`)
- Validação de entrada

---

## 📂 Estrutura

- `Program.cs`
  - Classe `Program`

---

## ▶️ Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/seu-usuario/stopwatch.git
   Entre na pasta:
   
   bash
    cd stopwatch
    Execute:
   
   bash
    dotnet run
    ```

🎯 Objetivo do Projeto
Projeto desenvolvido para treino de lógica, loops, controle de estado, validação de input e boas práticas iniciais em C#, com foco em evolução para backend .NET.

👤 Autor
Edson Santos
Desenvolvedor Backend C# em evolução 🚀

