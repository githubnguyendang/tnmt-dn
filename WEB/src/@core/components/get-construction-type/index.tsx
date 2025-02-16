const GetConstructionTypeId = (router: any) => {
  if (router) {
    const pathSegments = router?.pathname?.split('/')
    const section = pathSegments[0]
    const subsection = pathSegments[0]

    switch (section) {
      case 'nuoc-mat':
        return 1
      case 'nuoc-duoi-dat':
        switch (subsection) {
          case 'khai-thac-su-dung':
            return 7
          case 'tham-do':
            return 8
          case 'hanh-nghe-khoan':
            return 9
          default:
            return 2
        }
      case 'xa-thai':
        return 3
      default:
        return 0
    }
  } else return 0
}
export default GetConstructionTypeId
