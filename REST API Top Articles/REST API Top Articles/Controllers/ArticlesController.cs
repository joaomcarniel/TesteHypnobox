using Microsoft.AspNetCore.Mvc;
using REST_API_Top_Articles.Models;
using REST_API_Top_Articles.Services.Interfaces;

namespace REST_API_Top_Articles.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService articleService;
        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        /// <summary>
        /// Get para buscar artigos ordenados por número de comentários e título
        /// </summary>
        /// <param name="limit">Número Máximo de Artigos para Retornar</param>
        /// <response code="200">Retorna a lista encontrada</response>
        /// <response code="400">Retorno quando houver algum erro</response>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetTopArticles([FromQuery] int limit)
        {
            try
            {
                var articlesResponse = await articleService.GetTopCommentedArticles(limit);
                return Ok(articlesResponse);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }            
        }
    }
}
