# MoonsAPI

API Containing 219 moons from our solar system and their respective parents.

## Endpoints

| API|Description|
-------|-----------
|GET api/moons|Get all moon items
|GET api/parents|Get all parent items
|GET api/moons/{id}|Get a specific moon from a id
|POST api/moons/{id}|Create/Update a moon item
|DELETE api/Moons/{id}|Delete a moon item

## GET Request Example 

- Request
https://localhost:7063/api/moons/1
- Response
{"moonId":1,"moonName":"Moon","discoveryYear":"Prehistoric","discoveredBy":"—","parent":{"parentId":1,"parentName":"Earth"}}
