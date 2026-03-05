# Algoritmos: Atividade 01 — Atividade em sala 03/03/26

<table>
  <tr>
    <td width="160" valign="middle">
      <img src="https://novo.uniaraxa.edu.br/wp-content/uploads/2025/08/marca_oficial_uniaraxa_neg.png" alt="Centro Universitário do Planalto de Araxá" width="160" />
    </td>
    <td valign="middle">
      <strong>Centro Universitário do Planalto de Araxá</strong><br/>
      Curso: Sistemas de Informação<br/>
      Disciplina: Códigos de Alta Performance
    </td>
  </tr>
</table>

---

| | |
|---|---|
| **Trabalho** | Algoritmos: Atividade 01 — Atividade em sala 03/03/26 |
| **Professor** | Ricardo Alves |
| **Aluno(a)** | Yran Augusto |
| **Data** | 04/03/2026 |

---

## Objetivo

Refatorar uma tabela hash com falhas em colisões (endereçamento aberto) para **Separate Chaining** (encadeamento separado) com lista encadeada, mantendo a função de hash baseada na soma dos códigos ASCII.

## O que foi entregue

- **HashTable** (refatorada): array de buckets em que cada posição é uma lista encadeada (`HashNode`).
- **Função hash preservada:** `soma(ASCII da chave) % tamanho`.
- **Operações corrigidas:**
  - **Insert:** insere no bucket correspondente, evita duplicatas.
  - **Contains:** percorre apenas a lista do bucket; não quebra após remoções.
  - **Remove:** remove o nó da lista sem quebrar buscas de outros itens no mesmo bucket.

## Estrutura do projeto

```
Algoritmos Atividade 01/
├── Program.cs    # Aplicação de demonstração (seed, Contains, Remove, Dump)
├── HashTable.cs  # Tabela hash com Separate Chaining
├── HashNode.cs   # Nó da lista encadeada em cada bucket
└── TRABALHO.md   # Este documento
```

## Como executar

Na pasta do projeto:

```bash
dotnet run
```

Ao final, pressione ENTER para encerrar.

---

*Centro Universitário do Planalto de Araxá — Sistemas de Informação — Códigos de Alta Performance*
