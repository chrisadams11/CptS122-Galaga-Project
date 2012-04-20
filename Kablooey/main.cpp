
////////////////////////////////////////////////////////////
// Headers
////////////////////////////////////////////////////////////
#include "STDHeader.h"
#include "Globals.h"
#include "PlayerShip.h"
#include "Kablooey.h"
#include "Sprite.h"
#include "Projectile.h"
#include "Ship.h"
#include "EnemyShip.h"
////////////////////////////////////////////////////////////
/// Entry point of application
///
/// \return Application exit code
///
////////////////////////////////////////////////////////////
int main()
{
	Kablooey Game;//Create game object. Object loads and initialized in construction

    // Start game loop
    while (1)// Should later be replaced by "Game.IsRunning()", or something similar
    {
		
		Game.Update(/*GameTime.GetElapsedTime()*/);	//Not coded yet
		Game.Draw();	//Not coded yet
		
    }

    return EXIT_SUCCESS;
}
