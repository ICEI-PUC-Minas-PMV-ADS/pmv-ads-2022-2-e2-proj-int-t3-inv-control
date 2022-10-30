

//Mascara para input Telefone
const handlePhone = (event) => {
    let input = event.target
    input.value = phoneMask(input.value)
}

const phoneMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/(\d{2})(\d)/, "($1) $2")
    value = value.replace(/(\d)(\d{4})$/, "$1-$2")
    return value
}
//

//Mascara para input CEP
const handleCep = (event) => {
    let input = event.target
    input.value = cepMask(input.value)
}

const cepMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/(\d)(\d{3})$/, "$1-$2")
    return value
}
//

//Mascara para input CNPJ
const handleCnpj = (event) => {
    let input = event.target
    input.value = cnpjMask(input.value)
}

const cnpjMask = (value) => {
    if (!value) return ""
    value = value.replace(/\D/g, '')
    value = value.replace(/^(\d{2})(\d{3})(\d{3})(\d{3})(\d{4})(\d{2})/, "$1.$2.$3/$4-$5")
    return value
}
//