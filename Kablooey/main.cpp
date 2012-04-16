
////////////////////////////////////////////////////////////
// Headers
////////////////////////////////////////////////////////////
#include "STDHeader.h"

////////////////////////////////////////////////////////////
/// Entry point of application
///
/// \return Application exit code
///
////////////////////////////////////////////////////////////
int main()
{
	Kablooey Game;//Create game object. Object loads and initialized in construction
	Clock GameTime;
	
    // Create main window
    sf::RenderWindow App(sf::VideoMode(640, 480), "SFML Graphics");
	
    // Start game loop
    while (App.IsOpened())
    {
        Game.Update(GameTime.GetElapsedTime());	//Not coded yet
		
		Game.Draw();	//Not coded yet
		
    }

    return EXIT_SUCCESS;
}
