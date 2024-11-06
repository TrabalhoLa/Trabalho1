# Atividade de Threads

# Instruções
Essa atividade é composta de várias subatividades. 
Faça cada uma, individualmente coloque em uma pasta (pacote) os arquivos .java.
Faça em ordem pois a dificuldade de fazer funcionar é incremental.

# Atividade 01 - Runnable e Thread
Objetivo: Aprender a criar uma thread.
- Crie uma classe que implemente Runnable e que imprima a mensagem "Minha primeira thread" no console.
- Crie uma classe de testes o main. Neste método, crie um objeto da classe criada, adicione em uma thread e inicie.

# Atividade 02 - Duas threads
Objetivo: Colocar duas threads para rodar e notar que você não controla a ordem de execução.
- Crie uma classe que imprima os números pares, dormindo um tempo aleatório até 1s entre impressões
- Crie uma classe que imprima os números impares, dormindo um tempo aleatório até 1s entre impressões
- Crie uma classe de testes o main. Neste método, crie um objeto de cada classe, adicione em uma thread e inicie.

# Atividade 03 - Wait e Notify
Objetivo: Aprender a utilizar blocos sincronizados com wait e notify.
- Crie uma classe que imprima os números pares, aguardando a vez de imprimir.
- Crie uma classe que imprima os números impares, aguardando a vez de imprimir.
- Crie uma classe de testes o main. Neste método, crie um objeto de cada classe, adicione em uma thread e inicie.
Nota: Como a classe dos pares pode começar antes da classe dos impares, é possível que a sequência impressa seja 2, 1, 4, 3, 6, 5, ... ao invés de 1, 2, 3, 4, 5, 6, ... isso é indiferente para a solução.

# Atividade 04 - Variável compartilhada e Join
Objetivo: Utilizar uma variável de uma classe que é compartilhada entre várias threads e esperar todas as threads terminarem.
- Crie uma classe que seja um contador simples, mas que o valor seja incrementado em um método sincronizado.
- Crie 5 threads que incrementam esse valor 100.000 vezes (cada thread chama o método de incrementar 100.000 vezes).
- Antes da thread terminar, imprima "Thread x terminou de incrementar".
- Crie uma classe de testes o main. Neste método, crie um objeto de cada classe, adicione em uma thread e inicie.
- Espere as 5 threads terminarem usando join e imprima o valor do contador. Se tudo der certo, o valor deve ser 500.000.
Nota: Depois de iniciar a threads, dê join nela para esperar ela terminar. Só depois de todas terminarem que você deve ler o contador.


# Atividade 05 - Produtor e Consumidor
Objetivo: Sincronizar um acesso à uma fila comum.

- Faça uma classe Produtor que produz um elemento e guarda na fila.
- Faça uma classe Consumidor que retira um elemento da fila.
- Faça uma classe de testes que inicia um produtor e um consumidor e deixe rodando indefinidamente.
O tamanho da fila é indiferente para a solução, mas utilize pelo menos 10 espaços para levar algum tempo para encher.

# Atividade 06 - N Produtores  e M Consumidores
Objetivo: Sincronizar um acesso à uma fila comum.

- Faça uma classe Produtor que produz um elemento e guarda na fila.
- Faça uma classe Consumidor que retira um elemento da fila.
- Faça uma classe de testes que inicia vários produtores e vários consumidores, em quaisquer quantidades e deixe rodando indefinidamente.
O tamanho da fila é indiferente para a solução, mas utilize pelo menos 10 espaços para levar algum tempo para encher.
