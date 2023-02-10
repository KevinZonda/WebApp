# return 200 Hello
curl localhost:8080/hello

# return 200 []
curl localhost:8080/getQueue

# return 200
curl -H 'Content-Type: application/json' \
     -d '{ "content": "1"}' \
     -X POST \
     http://localhost:8080/pushQueue

# return 200 ["1"]
curl localhost:8080/getQueue

# return 409 duplicated
curl -H 'Content-Type: application/json' \
     -d '{ "content": "1"}' \
     -X POST \
     http://localhost:8080/pushQueue

# return 200 ["1"]
curl localhost:8080/getQueue

# return 200
curl -H 'Content-Type: application/json' \
     -d '{ "content": "2"}' \
     -X POST \
     http://localhost:8080/pushQueue

# return 200 ["1", "2"]
curl localhost:8080/getQueue