describe('Fluxo - Equipamentos', ()=>{

    beforeEach(()=> {
        cy.visit("http://localhost:3000")
    })

    it('Deve logar, cadastrar o produto e após 5 segundos ele excluirá automaticamente', ()=>{

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrincipal-nav-login').click()
        
        cy.get('.input__login').first().type('paulo@email.com')
        cy.get('.input__login').last().type('123456789')
        
        cy.get('#btn__login').click()
        
        cy.get('input[type=file]').first().selectFile('src/assets/tests/pat.jpg')
        
        cy.wait(1000)
        cy.get('#codigoPatrimonio').should('have.value', '1202560')
        cy.get('#nomePatrimonio').type('PC')
        cy.get('input[type=file]').last().selectFile('src/assets/tests/pat.jpg')
        cy.get('.btn__cadastro').click()
        
        cy.wait(500)
        cy.get('.card div h4').last().should('have.text','PC')
        cy.wait(5000)
        cy.get('.excluir').last().click()
        
    })
})