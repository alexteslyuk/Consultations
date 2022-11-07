const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:35513';

const PROXY_CONFIG = [
  {
    context: [
      "/api/Patient/GetAll",
      "/api/Patient/Get",
      "/api/Patient/Create",
      "/api/Patient/Edit",
      "/api/Patient/Delete",
      "/api/Consultation/Get",
      "/api/Consultation/Create",
      "/api/Consultation/Edit",
      "/api/Consultation/Delete"
   ],
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive'
    }
  }
]

module.exports = PROXY_CONFIG;
