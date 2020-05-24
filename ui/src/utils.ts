export const sortByStringValue = <T>(array: Array<T>, propName: string):Array<T> => {
    return array.slice().sort((a, b) => {
        // @ts-ignore
        const lowerCaseA = a[propName].toLowerCase(), lowerCaseB = b[propName].toLowerCase()
        if (lowerCaseA < lowerCaseB)
            return -1
        if (lowerCaseA > lowerCaseB)
            return 1
        return 0
    })
}
