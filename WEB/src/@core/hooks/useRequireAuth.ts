import { useCallback } from 'react'
import { useRouter } from 'next/router'
import { useAuth } from '../context/authContext'

export const useRequireAuth = () => {
  const { isLoggedIn, accessPermission, getToken } = useAuth()
  const router = useRouter()

  const hasPermission = useCallback(
    async (linkControl?: string, action?: string) => {
      if (!isLoggedIn) {
        router.push('/login')

        return false
      }

      if (!linkControl || !action) {
        return true
      }
      try {
        return await accessPermission(linkControl, action)
      } catch (error) {
        return false
      }
    },
    [isLoggedIn, accessPermission, router]
  )

  const getAuthToken = useCallback(() => {
    return getToken()
  }, [getToken])

  return { isLoggedIn, hasPermission, getAuthToken }
}
