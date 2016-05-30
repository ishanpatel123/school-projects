#include <Windows.h>
#include "TheGame.h"
#include "OGLShaderManager.h"
#include "GameEngine.h"
#include "OGLShaderManager.h"
#include "OGLGraphicsSystem.h"
#include "OGLViewingFrustum.h"
#include "GameWorld.h"
#include "LightSource.h"
#include "OGLCamera.h"
#include "CoreSystem.h"
#include "OGLVertexShader.h"
#include "TextFileReader.h"
#include "OGLFragmentShader.h"
#include "ObjectLoader.h"
#include "OGLFirstPersonCamera.h"
#include "OGLObject.h"
#include "RotateYBehavior.h"
#include "GameObjectManager.h"
#include "PCInputSystem.h"
#include "BackForthBehavior.h"
#include "OGL3DObject.h"
#include "OGL2DTextDisplay.h"
#include "BMPTextureLoader.h"
#include "OGL2DTexture.h"
#include "Plane.h"
#include "CustomTexture.h"
#include "Cuboid.h"
#include "Lamp.h"
#include "Tree.h"
#include "Sofa.h"
#include "FourPointPatrol.h"
#include "Patrol.h"
#include <gl\glew.h>
#include <glm\gtc\type_ptr.hpp>

TheGame::TheGame()
{
}

TheGame::~TheGame()
{
}

void TheGame::loadShaders()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	CoreSystem* core = this->gameEngine->getCoreSystem();
	TextFileReader *reader = core->getTextFileReader();

	graphics->addVertexShader(
		"SimpleVertexShader",
		new OGLVertexShader()
		);
	graphics->addVertexShader(
		"VertexShader3d",
		new OGLVertexShader(),
		reader->readContents("VertexShader3DPerspective.glsl")
		);
	graphics->addVertexShader(
		"VertexShaderIllumination",
		new OGLVertexShader(),
		reader->readContents("VertexShader3DIllumination.glsl")
		);
	graphics->addVertexShader(
		"VertexShaderTexture",
		new OGLVertexShader(),
		reader->readContents("VertexShaderTexture.glsl")
		);
	graphics->addVertexShader(
		"VertexShaderText",
		new OGLVertexShader(),
		reader->readContents("VertexShaderText.glsl")
		);

	graphics->addFragmentShader(
		"SimpleFragmentShader",
		new OGLFragmentShader()
		);
	graphics->addFragmentShader(
		"FragmentShaderIllumination",
		new OGLFragmentShader(),
		reader->readContents("FragmentShader3DIllumination.glsl")
		);
	graphics->addFragmentShader(
		"FragmentShaderTexture",
		new OGLFragmentShader(),
		reader->readContents("FragmentShaderTexture.glsl")
		);
	graphics->addFragmentShader(
		"FragmentShaderText",
		new OGLFragmentShader(),
		reader->readContents("FragmentShaderText.glsl")
		);

	this->shaderNames.push_back("SimpleShader");
	this->shaderNames.push_back("ShaderProgram3d");
	this->shaderNames.push_back("ShaderProgramIllumination");

	graphics->addShaderProgram(
		this->shaderNames[0],
		new OGLShaderProgram(),
		"SimpleVertexShader", "SimpleFragmentShader"
		);
	graphics->addShaderProgram(
		this->shaderNames[1],
		new OGLShaderProgram(),
		"VertexShader3d", "SimpleFragmentShader"
		);
	graphics->addShaderProgram(
		this->shaderNames[2],
		new OGLShaderProgram(),
		"VertexShaderIllumination", "FragmentShaderIllumination"
		);
	graphics->addShaderProgram(
		"TextureShader",
		new OGLShaderProgram(),
		"VertexShaderTexture", "FragmentShaderTexture"
		);
	graphics->addShaderProgram(
		"TextShader",
		new OGLShaderProgram(),
		"VertexShaderText", "FragmentShaderText"
		);
}

void TheGame::setupGraphicsParameters()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();

	OGLShaderProgram *shader;
	shader = (OGLShaderProgram*)shaderMgr->getShader(this->shaderNames[0]);
	if (shader) {
		// No uniform parameters for this shader
	}
	shader = (OGLShaderProgram*)shaderMgr->getShader(this->shaderNames[1]);
	if (shader) {
		shader->addUniform("cameraToScreenMatrix", Matrix4);
		shader->addUniform("worldToCameraMatrix", Matrix4);
		shader->addUniform("localToWorldMatrix", Matrix4);
	}
	shader = (OGLShaderProgram*)shaderMgr->getShader(this->shaderNames[2]);
	if (shader) {
		shader->addUniform("worldGlobalLightPos", Vector3);
		shader->addUniform("globalLightIntensity", Float);
		shader->addUniform("lightPositions", Vector3Array);
		shader->addUniform("numberOfLights", Integer);
		shader->addUniform("worldCameraPos", Vector3);
		shader->addUniform("cameraToScreenMatrix", Matrix4);
		shader->addUniform("worldToCameraMatrix", Matrix4);
		shader->addUniform("localToWorldMatrix", Matrix4);
		shader->addUniform("materialAmbientIntensity", Float);
		shader->addUniform("materialShininess", Float);
		shader->addUniform("materialSpecular", Vector4);
		shader->addUniform("lightIntensities", FloatArray);
	}
	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");
	if (shader) {
		shader->addUniform("worldGlobalLightPos", Vector3);
		shader->addUniform("globalLightIntensity", Float);
		shader->addUniform("lightPositions", Vector3Array);
		shader->addUniform("numberOfLights", Integer);
		shader->addUniform("worldCameraPos", Vector3);
		shader->addUniform("cameraToScreenMatrix", Matrix4);
		shader->addUniform("worldToCameraMatrix", Matrix4);
		shader->addUniform("localToWorldMatrix", Matrix4);
		shader->addUniform("materialAmbientIntensity", Float);
		shader->addUniform("materialShininess", Float);
		shader->addUniform("materialSpecular", Vector4);
		shader->addUniform("lightIntensities", FloatArray);
		shader->addUniform("tex", Sampler2D);
	}
}

void TheGame::setupViewingEnvironment()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLViewingFrustum* frustum = (OGLViewingFrustum*)graphics->getViewingFrustum();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	OGLShaderProgram* shader = 
		(OGLShaderProgram*)shaderMgr->getShader("ShaderProgramIllumination");
	shader->setUniformData(
		"cameraToScreenMatrix",
		(void*)glm::value_ptr(frustum->getMatrix()));
	shader->sendData("cameraToScreenMatrix");

	shader = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgram3d");
	shader->setUniformData(
		"cameraToScreenMatrix",
		(void*)glm::value_ptr(frustum->getMatrix()));
	shader->sendData("cameraToScreenMatrix");

	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");
	shader->setUniformData(
		"cameraToScreenMatrix",
		(void*)glm::value_ptr(frustum->getMatrix()));
	shader->sendData("cameraToScreenMatrix");

	// Cull back faces and use counter-clockwise winding of front faces
	glEnable(GL_CULL_FACE);
	glCullFace(GL_BACK);
	glFrontFace(GL_CCW);

	// Enable depth testing
	glEnable(GL_DEPTH_TEST);
	glDepthMask(GL_TRUE);
	glDepthFunc(GL_LEQUAL);
	glDepthRange(0.0f, 1.0f);

	
}

void TheGame::sendShaderData()
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLViewingFrustum* frustum = (OGLViewingFrustum*)graphics->getViewingFrustum();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	OGLShaderProgram* shader =
		(OGLShaderProgram*)shaderMgr->getShader("ShaderProgramIllumination");

	glm::vec3 globalLightPos = glm::vec3(100, 100, 0);
	shader->setUniformData(
		"worldGlobalLightPos",
		(void*)glm::value_ptr(globalLightPos));
	shader->sendData("worldGlobalLightPos");

	float globalLightIntensity = 0.1f;
	shader->setUniformData(
		"globalLightIntensity",
		(void*)&globalLightIntensity);
	shader->sendData("globalLightIntensity");

	GameWorld* gameWorld = graphics->getGameWorld();

	int numberOfLights = (int)gameWorld->localLights.size();
	shader->setUniformData(
		"numberOfLights",
		(void*)&numberOfLights);
	shader->sendData("numberOfLights");

	Vector3f lightPositions[10];
	float lightIntensities[10];
	for (int i = 0; i < numberOfLights; i++) {
		lightPositions[i] = gameWorld->localLights[i]->getPosition();
		lightIntensities[i] = gameWorld->localLights[i]->getIntensity();
	}
	shader->setUniformData(
		"lightPositions",
		(void*)lightPositions);
	shader->sendData("lightPositions");

	shader->setUniformData(
		"lightIntensities",
		(void*)lightIntensities);
	shader->sendData("lightIntensities");

	OGLCamera *camera = (OGLCamera*)gameWorld->getCamera();

	shader->setUniformData(
		"worldToCameraMatrix",
		(void*)glm::value_ptr(camera->orientation));
	shader->sendData("worldToCameraMatrix");

	shader->setUniformData(
		"worldCameraPos",
		(void*)glm::value_ptr(glm::vec3(camera->orientation[3])));
	shader->sendData("worldCameraPos");

	// Texture Shader
	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");

	shader->setUniformData(
		"worldGlobalLightPos",
		(void*)glm::value_ptr(globalLightPos));
	shader->sendData("worldGlobalLightPos");

	shader->setUniformData(
		"globalLightIntensity",
		(void*)&globalLightIntensity);
	shader->sendData("globalLightIntensity");

	shader->setUniformData(
		"numberOfLights",
		(void*)&numberOfLights);
	shader->sendData("numberOfLights");

	shader->setUniformData(
		"lightPositions",
		(void*)lightPositions);
	shader->sendData("lightPositions");

	shader->setUniformData(
		"lightIntensities",
		(void*)lightIntensities);
	shader->sendData("lightIntensities");

	shader->setUniformData(
		"worldToCameraMatrix",
		(void*)glm::value_ptr(camera->orientation));
	shader->sendData("worldToCameraMatrix");

	shader->setUniformData(
		"worldCameraPos",
		(void*)glm::value_ptr(glm::vec3(camera->orientation[3])));
	shader->sendData("worldCameraPos");

	shader = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgram3d");

	shader->setUniformData(
		"worldToCameraMatrix",
		(void*)glm::value_ptr(camera->orientation));
	shader->sendData("worldToCameraMatrix");

	shader->setUniformData(
		"worldCameraPos",
		(void*)glm::value_ptr(glm::vec3(camera->orientation[3])));
	shader->sendData("worldCameraPos");
}

void TheGame::setup(ObjectLoader* loader)
{
	OGLGraphicsSystem* graphics = (OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLShaderManager* shaderMgr = graphics->getOGLShaderManager();
	OGLShaderProgram* shader;

	loader->loadObjects(graphics->getGameWorld()->getObjectManager());
	graphics->setObjectsShaderProgram(this->shaderNames[2]);

	OGLFirstPersonCamera *camera =
		(OGLFirstPersonCamera *)graphics->getGameWorld()->getCamera();
	camera->setPosition(-5.0f, 5.0f, 8.0f);

	LightSource *light = new LightSource();
	light->setPosition(0.0f, 10.5f, 0.0f);
	light->setIntensity(1.2f);
	graphics->getGameWorld()->localLights.push_back(light);

	light = new LightSource();
	light->setPosition(9, 3, -13);
	light->setIntensity(1.2f);
	graphics->getGameWorld()->localLights.push_back(light);
	
	light = new LightSource();
	light->setPosition(9, 3, 13);
	light->setIntensity(1.2f);
	graphics->getGameWorld()->localLights.push_back(light);
	
	light = new LightSource();
	light->setPosition(-19, 10.5, 0);
	light->setIntensity(1.2f);
	graphics->getGameWorld()->localLights.push_back(light);

	light = new LightSource();
	light->setPosition(-14.5, 3, -11);
	light->setIntensity(1.2f);
	graphics->getGameWorld()->localLights.push_back(light);
	
	OGL3DObject* object3d = (OGL3DObject*)graphics->getGameObject("Sphere");
	
	shader = (OGLShaderProgram*)shaderMgr->getShader("ShaderProgram3d");

	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");
	OGLObject* object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Ground");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Left Wall");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Right Wall Room2");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Left Wall Room2");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Back Wall");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Front Wall");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Right Wall");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Roof");

	shader = (OGLShaderProgram*)shaderMgr->getShader("TextureShader");
	CustomTexture* tex = new CustomTexture();
	tex->create();
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Lamp1");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Lamp2");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Lamp3");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Tree1");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Tree2");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Tree3");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Sofa1");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Sofa2");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Sofa3");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Sofa4");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Sofa5");
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("owlFamily");
	object->setShaderProgram(shader->getHandle());
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("owlFamily2");
	object->setShaderProgram(shader->getHandle());
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("owlBook");
	object->setShaderProgram(shader->getHandle());
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("owlCook");
	object->setShaderProgram(shader->getHandle());
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("ROOM1");
	object->setShaderProgram(shader->getHandle());
	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("ROOM2");
	object->setShaderProgram(shader->getHandle());

	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("car");
	//object->setBehavior(new FourPointPatrol(10));

	object = (OGLObject*)
		graphics->getGameWorld()->getObjectManager()->getObject("Bird");
	//object->setBehavior(new Patrol(10));
}

void TheGame::processInputs()
{
	OGLGraphicsSystem* graphics = 
		(OGLGraphicsSystem*)this->gameEngine->getGraphicsSystem();
	OGLFirstPersonCamera *camera = 
		(OGLFirstPersonCamera *)graphics->getGameWorld()->getCamera();
	PCInputSystem* inputSystem = this->gameEngine->getInputSystem();

	camera->setJustLooking();
	camera->setNotMoving();

	if (inputSystem->keys[VK_LEFT]) {
		camera->setLookingLeft();
	}
	else if (inputSystem->keys[VK_RIGHT]) {
		camera->setLookingRight();
	}

	if (inputSystem->keys[VK_UP]) {
		camera->setLookingUp();
	}
	else if (inputSystem->keys[VK_DOWN]) {
		camera->setLookingDown();
	}

	if (inputSystem->keys['W']) {
		camera->setMovingForward();
	}
	else if (inputSystem->keys['S']) {
		camera->setMovingBackward();
	}
	if (inputSystem->keys['A']) {
		camera->setMovingLeft();
	}
	else if (inputSystem->keys['D']) {
		camera->setMovingRight();
	}

	if (inputSystem->isMouseMovingLeft()) {
		camera->setLookingLeft();
	}
	else if (inputSystem->isMouseMovingRight()) {
		camera->setLookingRight();
	}

	if (inputSystem->isMouseMovingUp()) {
		camera->setLookingUp();
	}
	else if (inputSystem->isMouseMovingDown()) {
		camera->setLookingDown();
	}
}
