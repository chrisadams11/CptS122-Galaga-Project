#include "Globals.h"
//#include "ObjectLists.h"
// Because of the way Static variables work, they still need to be initialized here. 
// The Viewport variables are examples of how to do this. You may set a value to the variable here, but you do not need to.
sf::Rect<float> Globals::Viewport1;
sf::Rect<float> Globals::Viewport2;
sf::Rect<float> Globals::ViewportFull;
int Globals::playerStats::playerDamage = 10;
int Globals::playerStats::playerHealth = 100;
int Globals::playerStats::playerSpeed = 10;
string Globals::playerStats::player1Sprite = "DirectionArrowSprite";
string Globals::playerStats::plater2Sprite = "DirectionArrowSprite";
//List<Projectile> Lists::ProjectileList = new List<Projectile>();