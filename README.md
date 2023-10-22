Ibanescu Dragos grupa 3133b




-Ce este un viewport?

Un viewport este o zona ferestrei in care vor fi desenate obiecte. Acesta are ca parametri x, y, latimea si inaltimea.

-Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?

FPS reprezinta numarul de cadre afisate pe secunda in cadrul unei aplicatii.

-Când este rulată metoda OnUpdateFrame()?

Metoda OnUpdateFrame() este rulata la fiecare cadru, înainte de a il desena, dar depinde si de parametrii functiei Run().

-Ce este modul imediat de randare?

Modul imediat este o abordare veche de randare.

-Care este ultima versiune de OpenGL care acceptă modul imediat?

OpenGL 3.2 este ultima versiune care accepta modul imediat.

-Când este rulată metoda OnRenderFrame()?

Metoda OnRenderFrame() este rulata la fiecare cadru dupa OnUpdateFrame().

-De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?

OnResize() initializeaza parametrii de vizualizare pentru a evita distorsiuni sau probleme de scalare.

-Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?

Parametrii includ unghiul de vedere (radiani), raportul de aspect, distanta la planul apropiat si distanta la planul indepartat, toti parametri fiind float.
