# InvertirOnlineChallenge
Esto es un proyecto de challenge de Invertir Online donde se refactoriza la clase FormaGeometrica y se crean nuevos test.

Aclaraciones:
- Al clonar el repo original de github https://github.com/invertironlineargentina/CodingChallenge tuve problemas con dos versiones de package del proyecto de Test: MSTest 1.1.11 y NUnit3TestAdapter 3.8. La solución fue desinstalarlas desde el administrador de paquetes de Nuget y volverlas a instalar con la misma versión. Luego limpiar y recompilar el proyecto. Luego de eso pude correr los test.
- Tomé por defecto el idioma inglés como decía la clase FormaGeometrica.cs.
- Los triángulos los pensé como una única clase ya que el área de cualquier tipo de triángulo es la misma. Si bien existen fórmulas para calcular el área de un triángulo según su tipo, no vi necesario hacer una subclase por cada tipo de triángulo porque el área es la misma en cualquier caso. Podría también haberlo pensado más declarativamente con una subclase de FormaGeometrica por cada tipo de triángulo e implementar la fórmula individual para el área de cada uno pero opté por la primera forma.
