# Description
For demo purposes only.
Runs a web api (/api/color) that returns either blue or green (or any other value) based on its configuration.


# Running

- Run an api that returns green:

`docker run -d xpiritbv/bluegreen:green`

- Run an api that returns blue:

`docker run -d xpiritbv/bluegreen:blue`

## Override the color

- Run an api that returns red, by redefining the environment variable 'color':

`docker run --name redapi -e color=red -d xpiritbv/bluegreen:blue`

- Test it by running curl inside a shell inside the container:

`docker exec -it redapi bash`

`curl -v http://localhost:8080/api/color`

Outputs:

```
*   Trying 127.0.0.1...
* TCP_NODELAY set
* Connected to localhost (127.0.0.1) port 8080 (#0)
> GET /api/color HTTP/1.1
> Host: localhost:8080
> User-Agent: curl/7.52.1
> Accept: */*
>
< HTTP/1.1 200 OK
< Date: Mon, 02 Sep 2019 09:22:33 GMT
< Content-Type: text/plain; charset=utf-8
< Server: Kestrel
< Transfer-Encoding: chunked
<
* Curl_http_done: called premature == 0
* Connection #0 to host localhost left intact
red
```