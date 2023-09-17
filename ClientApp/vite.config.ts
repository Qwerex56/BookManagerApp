import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'

import mkcert from 'vite-plugin-mkcert';

// https://vitejs.dev/config/
export default defineConfig({
  plugins: [vue(), mkcert()],
  server: {
    port: 3399,
    https: true,
    strictPort: true,
    proxy: {
      '/api': { 
        target: 'http://localhost:5054',
        changeOrigin: true,
        secure: false,
        rewrite: path => path.replace(/^\/api/, '/api'),
      },
    },
  }
})
