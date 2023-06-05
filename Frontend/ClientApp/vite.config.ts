
import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import mkcert from 'vite-plugin-mkcert'

export default defineConfig({
  plugins: [vue(), mkcert()],
  server: {
    port: 44488,
    https: true,
    strictPort: true,
    proxy: {
      '/api': {
        target: 'https://localhost:7222',
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/api/, '/api')
      },
      '/swagger': {
        target: 'https://localhost:7222',
        changeOrigin: true,
        secure: false,
        rewrite: (path) => path.replace(/^\/swagger/, '/swagger')
      }

    }
  }
})

