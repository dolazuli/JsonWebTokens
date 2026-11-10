# Getting started

Generate an RSA key pair in the project root and move the public key to the `JwksEndpoint` folder.

```
openssl genpkey -algorithm RSA -out private.pem -outpubkey public.pem
mv public.pem JwksEndpoint/
```

Build the image and start the container

```
docker compose up -d --build
```