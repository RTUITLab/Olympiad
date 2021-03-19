FROM nginx:alpine

RUN apk add --no-cache --update apache2-utils

COPY proxy.conf /etc/nginx/conf.d/proxy.conf
COPY 502.html /usr/share/nginx/html/502.html
COPY 404.html /usr/share/nginx/html/404.html
COPY 401.html /usr/share/nginx/html/401.html

COPY run.sh /run.sh
RUN sed -i $'s/\r$//' /run.sh
RUN chmod +x /run.sh

STOPSIGNAL SIGQUIT

ENTRYPOINT ["/run.sh"]