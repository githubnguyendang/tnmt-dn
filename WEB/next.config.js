/** @type {import('next').NextConfig} */

// Use require to import dotenv
require('dotenv').config()

const nextConfig = {
  reactStrictMode: true,
  env: {
    API_URL: process.env.API_URL,
    API_DEV: process.env.API_DEV,
    API_KEY_WINDY: process.env.API_KEY_WINDY
  }
}

module.exports = nextConfig
