
#user  nobody;
worker_processes  1;

#error_log  logs/error.log;
#error_log  logs/error.log  notice;
#error_log  logs/error.log  info;

#pid        logs/nginx.pid;


events {
    worker_connections  1024;
}


http {
    include mime.types;
default_type application/octet-stream;
    sendfile on;
keepalive_timeout  65;

upstream webtest
{ #weigth参数表示权值，权值越高被分配到的几率越大
		server 192.168.184.135:7001 weight=1 max_fails=2 fail_timeout=30s;#真实服务器A
		server 192.168.184.1:7001 weight=1 max_fails=2 fail_timeout=30s;#真实服务器B #这里是在30s内尝试2次失败即认为主机不可用！


    server
    {
        listen       8070;
        server_name localhost;
        location / {
            proxy_pass http://webtest;
        }
    }

}
