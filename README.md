# InvertirOnlineChallenge
Esto es un proyecto de challenge de Invertir Online donde se refactoriza la clase FormaGeometrica y se crean nuevos test.

Aclaraciones:
- Al clonar el repo original de github https://github.com/invertironlineargentina/CodingChallenge tuve problemas con dos versiones de package del proyecto de Test: MSTest 1.1.11 y NUnit3TestAdapter 3.8. La solución fue desinstalarlas desde el administrador de paquetes de Nuget y volverlas a instalar con la misma versión. Luego limpiar y recompilar el proyecto. Luego de eso pude correr los test.
- Tomé por defecto el idioma inglés como decía la clase FormaGeometrica.cs.
- Los triángulos los pensé como una única clase ya que el área de cualquier tipo de triángulo es la misma. Si bien existen fórmulas para calcular el área de un triángulo según su tipo, no vi necesario hacer una subclase por cada tipo de triángulo porque el área es la misma en cualquier caso. Podría también haberlo pensado más declarativamente con una subclase de FormaGeometrica por cada tipo de triángulo e implementar la fórmula individual para el área de cada uno pero opté por la primera forma.


## **La solución**

- Se refactoriza la clase FormaGeometrica que se encuentra muy acoplada por una clase abstracta que representa una FormaGeometrica cualquiera. Se crea una subclase por cada tipo de forma que hereda FormaGeometrica implementando cada una sus cálculos propios de áreas y perímetros según corresponda.
- Se inyecta a FormaGeometrica un componente de idioma pensado como una Interfaz para la traudcción de los textos en diferentes idiomas. Cada idioma nuevo que se agrega será una clase que implemente la interfaz común Lenguaje. La traducción se lleva a cabo mediante la búsqueda en un dicctionary de clave/valor. También podía haberse implementado como un archivo json con objetos de traducciones con textos ya preestablecidos.
- Se crean nuevos test para la nueva solución.


