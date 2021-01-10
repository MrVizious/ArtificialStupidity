# Artificial Stupidity

Trabajo realizado por Javier Riera para la Práctica Final de Programación 2D

# El Juego
Eres un técnico en una empresa de un futuro no demasiado lejano, y te han pedido que ayudes a uno de sus trabajadores a realizar pruebas para comprobar que su inteligencia artificial funciona debidamente. Él tendrá contacto contigo para comunicarte qué debes hacer, así que simplemente sigue sus instrucciones.

# El código

## InputModifiers

Por desgracia no he aprovechado el tiempo como debía y al final no he podido mostrar en gameplay todo lo que quería. Hay implementados 3 tipos de modificadores de pulsación:

- MultitapInputModifier: Obliga a pulsar varias veces el botón para que sea registrado
- HardToPressInputModifier: Oliga a mantenerlo pulsado durante un rato para que se detecte
- DelayInputModifier: Hace que el input vaya con retraso

Son funcionales y lo único que hay que hacer es arrastrar sus scripts desde su carpeta (Assets/Scripts/Platforms/InputModifiers) a cada una de las plataformas y reconectar el onButtonDown y onButtonUp correspondientes para que les apunten.

## Input
Se utiliza una clase InputManager de la cual deriva el resto según su función, y solo actualizan los datos necesarios. De la misma manera, en cada nivel hay un GameObject PlayerInput que alberga un InputManager concreto para usuarios y que sirve para que los scripts button que se le asocien puedan saber cuándo se ha pulsado. Estos script Button tienen un evento onButtonDown y uno onButtonUp que se deben apuntar tanto a la plataforma que se desee como a su gráfico de qué tecla es y que así haya input no solo mecánico sino visual.

# Vídeo
El vídeo de demostración se halla en la carpeta Video. Es algo largo pero es debido a que el juego tiene mucha naraación y las mecánicas no se ven hasta casi pasados los dos minutos.
