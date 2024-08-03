# Diagrama de Clases del Juego de Pac-Man e Implementacion

# Descripcion:
El juego que hemos relizado es Pac-Man el cual es un juego de acción de laberintos el mismo que fue desarrollado e implusado por Namco en 1980. 
El juego trata de que el jugador controla a Pac-Man, el cual que debe comerse todos los puntos dentro de un laberinto cerrado mientras evita a cuatro fantasmas de colores. Al comer unos puntos grandes y parpadeantes llamados "Super Pildoras", los fantasmas se vuelven azules, lo que permite a Pac-Man comérselos para conseguir puntos extra.

![image](https://github.com/user-attachments/assets/2e73c5b4-1df7-4e80-8f0c-dccff2e1db74)

# Diagrama de Clases version 1.0
![352242947-b38105fd-9118-4b60-9121-23c788c15763](https://github.com/user-attachments/assets/e1c1035a-0bc9-43dd-a4ca-cf563be57839)

# Diagrama de Clases version 1.1
![DiagramaUML_Juego_PacMan](https://github.com/user-attachments/assets/7b596c69-ee6e-40e9-abb6-f3c4009dad4a)

## Descripción de las Clases

### GestorJuego
Gestiona el estado del juego, inicia y actualiza niveles, y maneja el puntaje del jugador.
- **Métodos**:
  - `iniciarJuego()`
  - `actualizar()`
  - `finJuego()`
  - `iniciarNivel(nivel: int)`
  - `actualizarPuntaje(puntos: int)`

### EstadoJuego
Define los posibles estados del juego.
- **Valores de Enumeración**:
  - `JUGANDO`
  - `FIN_JUEGO`

### Jugador

- **Atributos**:
  - `nombre: String`
  - `puntajeMaximo: int`
- **Métodos**:
  - `obtenerPuntaje()`
  - `actualizarPuntaje(puntos: int)`

### Laberinto
Genera el laberinto.
- **Métodos**:
  - `generar()`

### Pildora

- **Atributos**:
  - `puntos: int`
  - `posicion: Vector2`
- **Métodos**:
  - `comer()`

### PildoraPequeña

- Hereda las características de `Pildora`.

### SuperPildora

- **Métodos**:
  - `activarModoAsustado()`

### PacMan

- **Atributos**:
  - `velocidad: float`
  - `direccion: Vector2`
  - `posicion: Vector2`
- **Métodos**:
  - `mover()`
  - `comerPildora(pildora: Pildora)`
  - `comerSuperPildora(superPildora: SuperPildora)`
  - `morir()`

### Fantasma

- **Atributos**:
  - `velocidad: float`
  - `direccion: Vector2`
  - `posicion: Vector2`
  - `modoDisperso: boolean`
  - `modoAsustado: boolean`
- **Métodos**:
  - `mover()`
  - `perseguir()`
  - `dispersar()`
  - `huir()`

### Vector2

- **Atributos**:
  - `x: float`
  - `y: float`
- **Métodos**:
  - `Vector2(x: float, y: float)`

## Relación entre Clases

- **GestorJuego** gestiona al **Jugador**.
- **Laberinto** contiene **PildoraPequeña** y **SuperPildora**, y a **PacMan** y **Fantasma**.
- **PacMan** interactúa con **SuperPildora** para activar el modo asustado en los fantasmas.
- **Fantasmas** persiguen a **PacMan**.
- **PacMan** come **PildoraPequeña** y **SuperPildora**.

## Funcionalidad General
* GestorJuego inicia el juego y genera un nuevo laberinto.
* PacMan y Fantasma se mueven en el interior del laberinto.
* PacMan puede comer píldoras esto hace que aumente su puntaje y si come "Super píldoras" se activa el modo asustado en los fantasmas .
* GestorJuego actualiza el estado del juego, incluyendo el puntaje y el estado del jugador.
* Si PacMan es atrapado por un fantasma y ya no tiene vidas, el juego puede terminar .
* Por cada vez que se logre comer PacMan a los fantasmas, se irá incrementando la difcultad.

## Ejecucion del Juego
### Este juego ha sido realizado en Unity por lo que se debe tener instalado Unity en su computador y un Editor.
1. Clonar el repositorio en tu espacio de trabajo.
   Link del repositorio: https://github.com/Jossibel/InterfazJuego.git
   * Usando Git Bash
   ![image](https://github.com/user-attachments/assets/17537b2d-090b-4f98-a109-e478444d41e5)
 * Usando GitHub Desktop
   ![image](https://github.com/user-attachments/assets/32c306c5-d8de-4d2a-b839-43019dbf6055)
   
2. Una vez clonado el repositorio otra opcion es descargar el archico .zip

   ![image](https://github.com/user-attachments/assets/4fd8611d-04a7-4888-8ad7-ab46eca35d5d)
   
3. Una vez descargado o clonado los archivos, abrimos Unity y en la pestaña "Add" y seleccionamos la carpeta donde se encuntran los archivos.

   ![image](https://github.com/user-attachments/assets/2cc83b05-043e-4655-9d30-8ca08604be76)
   
   ![image](https://github.com/user-attachments/assets/5a6f0ca4-8f3a-44a8-8971-2aa0e6e77528)
   
4. Se abrira una pestaña y se comezaran a descargar los archivos

   ![image](https://github.com/user-attachments/assets/9863923c-05a3-4104-94ec-a4d34d5c6536)
   
5. Una vez finalizada la descarga, aparecera en la parte de "Projects" nuestro archivo, y lo seleccionamos.

   ![image](https://github.com/user-attachments/assets/8bd63249-5755-42db-9ed0-e26142d83f5b)
   
   ![image](https://github.com/user-attachments/assets/c8948257-78e0-4930-9537-e6f31a468238)
6. Posteriormente se abrira el archivo.

    ![image](https://github.com/user-attachments/assets/e708b7d2-cb0b-4634-8b6e-3c492a9da1ac)
    
7. Luego, en la parte de "Projects", seleccionamos la carpeta "Scenes".
    
   ![image](https://github.com/user-attachments/assets/6b187434-67da-4c22-88ab-5d92e6b3546c)
   
   ![image](https://github.com/user-attachments/assets/ffef8bd4-9039-4a7f-b0d4-68cc764788d9)
   
   ![image](https://github.com/user-attachments/assets/ee024bae-c798-4009-8bfd-ee4f8d532e92)
   
8. Por ultimo, damos "Play".
    
   ![image](https://github.com/user-attachments/assets/942d77ca-a6ca-4d9a-8399-84597396317a)
   
   ![image](https://github.com/user-attachments/assets/7e6bed57-a481-4648-a2b1-7f019a2443f0)


# Integrantes:

* Jossibel Perez
* Maria Chuico
