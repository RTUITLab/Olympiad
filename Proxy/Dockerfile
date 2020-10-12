FROM nginx:alpine

RUN apk add --no-cache --update apache2-utils

COPY proxy.conf /etc/nginx/conf.d/proxy.conf

COPY run.sh /run.sh
RUN chmod +x /run.sh

STOPSIGNAL SIGQUIT

ENTRYPOINT ["/run.sh"]