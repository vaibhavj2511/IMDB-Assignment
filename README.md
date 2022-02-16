# REST API application using .Net Core ASP

This is a IMDB-like REST API example with 3 endpoints of a sample Movie application.
Using these 3 endpoints, we can List,Add,Update movies.

# REST API

The REST API to the movie app is described below.



## Get list of Movies

### Request

`GET /movies/all`

### Response

    [
  {
    "id": 1,
    "name": "The Matrix",
    "yor": 1999,
    "plot": "Future and Past walkthrough",
    "producers": {
      "id": 1,
      "name": "Warner Bros",
      "gender": "Male",
      "dob": "1960-05-14T00:00:00",
      "bio": "Known for hypothetical concepts in movies."
    },
    "actor": [
      {
        "id": 1,
        "name": "Keanu Reeves",
        "bio": "Action hero",
        "dob": "0001-01-01T00:00:00",
        "gender": "Male"
      },
    "genre": [
      {
        "id": 2,
        "name": "Action"
      }
    ]
  },.......
  ]




## Create a new Movie

### Request

`POST /movies`

{
  "id": 0,
  "name": "The Matrix",
  "yor": 1999,
  "plot": "Future and Past walkthrough",
  "producerId": 1,
  "actors": [
    1
  ],
  "genres": [
    2
  ]
}

### Response

    Status: 201 Created
    {id:1}





## Update a movie

### Request

`PUT /movies/{id}`

**Paramter {id} is the id of the movie which needs to be updated.**

{
  "id": 10365,
  "name": "Bahubali",
  "yor": 2015,
  "plot": "King returns",
  "producerId": 2,
  "actors": [
    2
  ],
  "genres": [
    1
  ]
}

### Response

    Movie Updated Sucessfully.....
