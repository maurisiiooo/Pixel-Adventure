# Pixel-Adventure
# Documentación del Proyecto de Desarrollo en Unity

Repositorio formal 

## Controles del Juego

- Movimiento del Personaje: Controlado mediante las teclas de dirección tradicionales o el sistema de navegación asignado por el motor (generalmente W, A, S, D o flechas direccionales).
- Interacción con Objetos (Cofres y elementos del entorno):** Se ejecuta presionando la Tecla E cuando el personaje se encuentra dentro del radio de proximidad del trigger de colisión.
- Sistema de Pausa / Menús (si aplica): Acceso mediante la Tecla Escape (Esc) según la configuración estándar del motor.

## Arquitectura de Mecánicas de Gameplay

- Sistema de Reaparición y Control de Puntos de Inicio (Respawn): Implementación de lógica de detección mediante eventos de colisión Trigger. Al establecer contacto físico con áreas designadas como trampas de pinchos, el sistema ejecuta de manera inmediata el cambio de coordenadas posicionales del jugador hacia la referencia asignada en el componente PuntoInicio.

- Sistema de Cofres Interactivos y Gestión de Recompensas: Arquitectura basada en zonas de proximidad utilizando scripts personalizados de control. La interacción se encuentra condicionada por la validación de la etiqueta de identificación del jugador (Player) y la lectura del búfer de entrada mediante la Tecla E. Tras la activación, el script modifica dinámicamente las propiedades del material visual del cofre (cambio de color a tono amarillo) y activa de forma simultánea un objeto hijo configurado previamente como prefab de recompensa (moneda tridimensional con escala específica de $0.5 \times 0.1 \times 0.5$).

- Gestión de Físicas y Cinemática del Personaje: Integración de componentes de movimiento Character Controller respaldados por un objeto Rigidbody configurado en modo cinemático (Is Kinematic). Esta parametrización técnica garantiza la resolución exacta de colisiones frontales y el funcionamiento correcto de los métodos OnTriggerEnter y OnTriggerExit.

## Especificaciones del Entorno de Desarrollo

- Entorno de Motor: Unity (compatible con versiones 2022 LTS o superiores).
- Lenguaje de Programación: C# (con gestión de scripts orientada a componentes).
- Control de Entradas: Input Manager estándar de Unity enfocado en la detección de eventos de teclado y proximidad tridimensional.

## Estructura de Directorios del Repositorio

- Assets/: Contiene los recursos lógicos y multimedia del videojuego, incluyendo códigos fuente (.cs), materiales gráficos, escenas principales, prefabs y modelos geométricos.
- ProjectSettings/: Almacena los archivos de configuración interna del motor, ajustes de capas físicas, mapas de entrada y parámetros de renderizado del proyecto.

## Guía de Despliegue e Inicialización

1. Realice la descarga y extracción del archivo comprimido (.zip) contenedora del código fuente y los recursos del proyecto en un directorio local.
2. Inicie la interfaz de gestión Unity Hub.
3. Seleccione la opción de añadir proyectos existentes desde disco (Add project from disk) y elija la carpeta descomprimida del repositorio.
4. Abra el proyecto con la versión correspondiente del editor y proceda a cargar la escena principal de trabajo para la ejecución en modo de pruebas o depuración de código.
