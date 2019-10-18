FROM ubuntu:18.10

RUN apt update && \
    apt install sqlite3 -y && \
    mkdir dbfile

WORKDIR /dbfile

COPY . /dbfile

## Run: docker run {TAG} -it /bin/bash